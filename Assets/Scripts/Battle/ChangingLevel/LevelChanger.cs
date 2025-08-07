public class LevelChanger : IGameEvent
{
    private IMover _playerMover;
    private ISpawner _waveSpawner, _backgroundSpawner;
    private IEventCaller _eventCaller;

    public LevelChanger(IMover playerMover, ISpawner backgroundSpawner, ISpawner waveSpawner, IEventCaller eventCaller)
    {
        _playerMover = playerMover;
        _backgroundSpawner = backgroundSpawner;
        _waveSpawner = waveSpawner;
        _eventCaller = eventCaller;
    }

    public void Play()
    {
        _playerMover.Move();
        _backgroundSpawner.Spawn();
        _waveSpawner.Spawn();
        // Delay
        _eventCaller.PlayNext();
    }
}
