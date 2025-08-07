using UnityEngine;

public class BackgroundSpawner : ISpawner
{
    private IPoolManager _poolManager;
    private GameObject _currentBackground;
    private Vector3 _spawnPosition;
    private float _spawnOffset;

    public BackgroundSpawner(IPoolManager poolManager, float spawnOffset)
    {
        _poolManager = poolManager;
        _spawnOffset = spawnOffset;
        Spawn();
    }

    public void Spawn()
    {
        _poolManager.InstantiateFromPool("background", _spawnPosition, Quaternion.identity);
        _spawnPosition += Vector3.right * _spawnOffset;
    }
}
