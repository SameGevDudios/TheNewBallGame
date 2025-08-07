public class LevelChanger : IGameEvent
{
    private IPlayerMover _playerMover;
    private IBackgroundSpawner _backgroundSpawner;

    public LevelChanger(IPlayerMover playerMover, IBackgroundSpawner backgroundSpawner)
    {
        _playerMover = playerMover;
        _backgroundSpawner = backgroundSpawner;
    }

    public void Play()
    {
        _playerMover.Move();
        _backgroundSpawner.Spawn();
    }
}
