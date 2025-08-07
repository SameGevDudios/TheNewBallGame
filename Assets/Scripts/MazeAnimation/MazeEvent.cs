using UnityEngine;

public class MazeEvent : IGameEvent
{
    private ISpawner _spawner;
    private IMover _cameraMover, _mazeMover;
    private IEventCaller _eventCaller;
    private Transform _currentMaze;
    private bool _moveUp;

    public MazeEvent(ISpawner spawner, IMover cameraMover, IMover mazeMover, IEventCaller eventCaller)
    {
        _spawner = spawner;
        _cameraMover = cameraMover;
        _mazeMover = mazeMover;
        _eventCaller = eventCaller;
    }

    public void Play()
    {
        if (_moveUp)
        {
           _currentMaze.gameObject.SetActive(false);
        }
        else
        {
            _currentMaze = _spawner.Spawn().transform;
            _mazeMover.SetNewMovable(_currentMaze);
            _eventCaller.PlayNext();
        }
        _cameraMover.Move();
        _mazeMover.Move();
        _moveUp = !_moveUp;
        // Delay
    }
}
