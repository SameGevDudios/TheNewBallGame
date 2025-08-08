using UnityEngine;

public class MazeSpawner : ISpawner
{
    private IPoolManager _poolManager;
    private Transform _spawnAnchor;
    private float _spawnOffsetY;
    private int _currentMaze, _maxMaze;

    public MazeSpawner(IPoolManager poolManager, Transform spawnAnchor, float spawnOffsetY, int maxMaze)
    {
        _poolManager = poolManager;
        _spawnAnchor = spawnAnchor;
        _spawnOffsetY = spawnOffsetY;
        _maxMaze = maxMaze;
    }

    public GameObject Spawn()
    {
        Vector2 spawnPosition = _spawnAnchor.position + Vector3.down * _spawnOffsetY;
        GameObject buffer = _poolManager
            .InstantiateFromPool($"maze{_currentMaze}", spawnPosition, Quaternion.identity);
        NextMaze();
        return buffer;
    }

    public GameObject Spawn(Vector3 position)
    {
        GameObject buffer = Spawn();
        buffer.transform.position = position;
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
