using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class EventCaller : IEventCaller
{
    private Queue<IGameEvent> _gameLoop = new();
    private IGameEvent _currentEvent;
    private int _beforeEventDelay, _afterEventDelay;

    public EventCaller(float beforeEventDelay, float afterEventDelay)
    {
        _beforeEventDelay = (int)(beforeEventDelay * 1000);
        _afterEventDelay = (int)(afterEventDelay * 1000);
    }

    public void Add(IGameEvent newEvent)
    {
        _gameLoop.Enqueue(newEvent);
    }

    public async Task PlayNext(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        await Task.Delay(_beforeEventDelay);

        _currentEvent = _gameLoop.Dequeue();
        _gameLoop.Enqueue(_currentEvent);

        await Task.Delay(_afterEventDelay);

        _currentEvent.Play();
    }
}
