using UnityEngine;

public class BackgroundSpawner : IBackgroundSpawner
{
    private PoolManager _poolManager;
    private GameObject _currentBackground;
    private Vector3 _spawnPosition;
    private float _spawnOffset;

    public BackgroundSpawner(PoolManager poolManager, float spawnOffset)
    {
        _poolManager = poolManager;
        _spawnOffset = spawnOffset;
        SpawnNewBackground();
    }

    public void SpawnNewBackground()
    {
        _poolManager.InstantiateFromPool("background", _spawnPosition, Quaternion.identity);
        _spawnPosition += Vector3.right * _spawnOffset;
    }
}
