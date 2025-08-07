public class MazeEvent : IGameEvent
{
    private VerticalMover _cameraMover, _mazeMover;
    private IEventCaller _eventCaller;

    public MazeEvent(VerticalMover cameraMover, VerticalMover mazeMover, IEventCaller eventCaller)
    {
        _cameraMover = cameraMover;
        _mazeMover = mazeMover;
        _eventCaller = eventCaller;
    }

    public void Play()
    {
        _cameraMover.Move();
        _mazeMover.Move();
        // Delay
        _eventCaller.PlayNext();
    }
}
