using System.Collections.Generic;

public class EventCaller : IEventCaller
{
    private Queue<IGameEvent> _gameLoop = new();
    private IGameEvent _currentEvent;

    public void Add(IGameEvent newEvent)
    {
        _gameLoop.Enqueue(newEvent);
    }

    public void PlayNext()
    {
        _currentEvent = _gameLoop.Dequeue();
        _gameLoop.Enqueue(_currentEvent);
        _currentEvent.Play();
    }
}
