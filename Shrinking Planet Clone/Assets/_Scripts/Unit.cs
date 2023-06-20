using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public event EventHandler OnUnitSpawned;
    public event EventHandler OnUnitMoved;
    public event EventHandler OnUnitReachedDesk;
    public event EventHandler OnUnitBeganWork;

    [SerializeField] private UnitSO _unitSO;

    private enum State
    {
        Idle,
        Walking,
        Working,
        Leaving,
    }

    private State _currentState;

    private float _timer = 0f;
    private float _moveSpeed = 4f;
    private float _rotateSpeed = 10f;
    private float _stoppingDistance = .1f;

    private bool _wasCalled;

    private void Start()
    {
        _currentState = State.Idle;
        OnUnitSpawned?.Invoke(this, EventArgs.Empty);
    }

    private void Update()
    {
        StateMachine();
    }

    private void StateMachine()
    {
        switch (_currentState)
        {
            case State.Idle:
                if (_timer >= 5f)
                {
                    _currentState = State.Walking;
                    _timer = 0f;
                }
                else
                {
                    _timer += Time.deltaTime;
                }
                break;
            case State.Walking:
                if (!_wasCalled)
                {
                    MoveUnit();
                }
                else
                {
                    _currentState = State.Working;
                    _wasCalled = false;
                }
                break;
            case State.Working:
                if (!_wasCalled)
                {
                    OnUnitReachedDesk?.Invoke(this, EventArgs.Empty);
                    _wasCalled = true;
                }
                else
                {
                    HandleUnitJob();
                }
                break;
            case State.Leaving:
                break;
        }
    }

    private void MoveUnit()
    {
        Vector3 moveDirection = (GetUnitDeskPosition() - transform.position).normalized;

        // Set rotation in which Unit is looking
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * _rotateSpeed);

        if (Vector3.Distance(transform.position, GetUnitDeskPosition()) > _stoppingDistance)
        {
            // If can move -> move
            transform.position += _moveSpeed * Time.deltaTime * moveDirection;
        }
        else
        {
            _wasCalled = true;
        }
    }

    private void HandleUnitJob()
    {
        if (UnitActionSystem.Instance.TryGetSelectedUnit(out Unit selectedUnit))
        {
            if (ReferenceEquals(selectedUnit, this))
            {
                OnUnitBeganWork?.Invoke(this, EventArgs.Empty);
            } 
        }
    }

    public string GetUnitGreetingsText() => _unitSO.Greetings;

    public Vector3 GetUnitDeskPosition() => _unitSO.UnitTargetDeskPosition;
}
