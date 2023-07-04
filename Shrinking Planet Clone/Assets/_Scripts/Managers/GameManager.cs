public class GameManager : Singleton<GameManager>
{
    public enum GameMode
    {
        Interview,
        Working,
    }

    private GameMode _currentGameMode;

    protected override void Awake()
    {
        base.Awake();

        _currentGameMode = GameMode.Interview;
    }

    public GameMode GetCurrentGameMode()
    {
        return _currentGameMode;
    }
}
