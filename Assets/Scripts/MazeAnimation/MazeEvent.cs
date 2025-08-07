public class MazeEvent : IGameEvent
{
    private ISpawner _spawner;
    private IMover _cameraMover, _mazeMover;
    private IEventCaller _eventCaller;

    public MazeEvent(ISpawner spawner, IMover cameraMover, IMover mazeMover, IEventCaller eventCaller)
    {
        _spawner = spawner;
        _cameraMover = cameraMover;
        _mazeMover = mazeMover;
        _eventCaller = eventCaller;
    }

    public void Play()
    {
        _mazeMover.SetNewMovable(_spawner.Spawn().transform);
        _cameraMover.Move();
        _mazeMover.Move();
        // Delay
        _eventCaller.PlayNext();
    }
}
