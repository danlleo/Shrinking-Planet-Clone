using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private const float PAUSE_TIME_SCALE = 0f;

    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnpaused;

    private bool _isPaused;

    private float _previousTimeScale = 1f;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        if (!InputManager.Instance.IsPauseButtonDownThisFrame())
            return;

        if (_isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        OnGamePaused?.Invoke(this, EventArgs.Empty);
        _isPaused = true;
        _previousTimeScale = Time.timeScale;
        Time.timeScale = PAUSE_TIME_SCALE;
    }

    public void Resume()
    {
        OnGameUnpaused?.Invoke(this, EventArgs.Empty);
        _isPaused = false;
        Time.timeScale = _previousTimeScale;
    }
}
