using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log($"Event order: {JoinQueue<IGameEvent>(_gameLoop)}");
        _currentEvent = _gameLoop.Dequeue();
        Debug.Log($"Now executing event {_currentEvent}.");
        _gameLoop.Enqueue(_currentEvent);
        _currentEvent.Play();
    }

    string JoinQueue<T>(Queue<T> q) => string.Join(" ", q);
}
