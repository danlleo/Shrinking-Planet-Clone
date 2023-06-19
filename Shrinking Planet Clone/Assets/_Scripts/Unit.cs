using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public event EventHandler OnUnitSpawned;
    public event EventHandler OnUnitMoved;
    public event EventHandler OnUnitReachedDesk;

    [SerializeField] private UnitSO _unitSO;

    private BaseAction[] _baseActionArray;

    private enum State
    {
        Idle,
        Walking,
        Working,
        Leaving,
    }

    private State _currentState;

    private float timer = 0f;
    private bool _wasCalled;

    private void Awake()
    {
        _baseActionArray = GetComponents<BaseAction>();
    }

    private void Start()
    {
        BaseAction baseAction = GetComponent<BaseAction>();
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
                if (timer >= 5f)
                {
                    _currentState = State.Walking;
                    timer = 0f;
                }
                else
                {
                    timer += Time.deltaTime;
                }
                break;
            case State.Walking:
                if (timer >= 5f)
                {
                    _currentState = State.Working;
                    timer = 0f;
                    _wasCalled = false;
                }
                else
                {
                    if (!_wasCalled)
                    {
                        OnUnitMoved?.Invoke(this, EventArgs.Empty);
                        _wasCalled = true;
                    }

                    timer += Time.deltaTime;
                }
                
                break;
            case State.Working:
                if (!_wasCalled)
                {
                    OnUnitReachedDesk?.Invoke(this, EventArgs.Empty);
                    _wasCalled = true;
                }
                break;
            case State.Leaving:
                break;
        }
    }

    public T GetAction<T>() where T : BaseAction
    {
        foreach (BaseAction baseAction in _baseActionArray)
        {
            if (baseAction is T t)
                return t;
        }

        return null;
    }
    
    public string GetUnitGreetingsText() => _unitSO.Greetings;

    public Vector3 GetUnitDeskPosition() => _unitSO.UnitTargetDeskPosition;
}
