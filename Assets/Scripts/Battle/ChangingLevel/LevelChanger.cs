public class LevelChanger : IGameEvent
{
    private IMover _playerMover;
    private IWaveSpawner _waveSpawner;
    private IBackgroundSpawner _backgroundSpawner;
    private IEventCaller _eventCaller;

    public LevelChanger(IMover playerMover, IBackgroundSpawner backgroundSpawner, IWaveSpawner waveSpawner, IEventCaller eventCaller)
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
