using UnityEngine;

public class MazeSpawner : ISpawner
{
    private IPoolManager _poolManager;
    private Transform _player;
    private float _spawnOffsetY;
    private int _currentMaze, _maxMaze;

    public MazeSpawner(IPoolManager poolManager, Transform player, float spawnOffsetY, int maxMaze)
    {
        _poolManager = poolManager;
        _player = player;
        _spawnOffsetY = spawnOffsetY;
        _maxMaze = maxMaze;
    }

    public GameObject Spawn()
    {
        GameObject buffer = _poolManager
            .InstantiateFromPool($"maze{_currentMaze}", _player.position + Vector3.down * _spawnOffsetY, Quaternion.identity);
        NextMaze();
        return buffer;
    }

    private void NextMaze()
    {
        _currentMaze++;
        if(_currentMaze == _maxMaze)
        {
            _currentMaze = 0;
        }
    }
}
