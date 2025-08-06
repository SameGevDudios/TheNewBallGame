using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : IWaveSpawner
{
    private IPoolManager _poolManager;
    private List<Wave> _waves = new();
    private int _currentWave;

    public WaveSpawner(IPoolManager poolmanager, List<Wave> waves) 
    {
        _poolManager = poolmanager;
        _waves = waves;
    }

    public void Spawn(out int enemyCount)
    {
        enemyCount = _waves[_currentWave].Enemies.Count;
        foreach(Wave.Enemy enemy in _waves[_currentWave].Enemies) 
        {
            _poolManager.InstantiateFromPool(enemy.EnemyObject.name, enemy.Position, Quaternion.identity);
        }
        _currentWave = Mathf.Min(_currentWave + 1, _waves.Count - 1);
    }
}
