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

    public Queue<Battling> Spawn()
    {
        Queue<Battling> enemies = new();
        foreach(Wave.Enemy enemy in _waves[_currentWave].Enemies) 
        {
            GameObject buffer = _poolManager.InstantiateFromPool(enemy.EnemyObject.name, enemy.Position, Quaternion.identity);
            enemies.Enqueue(buffer.GetComponent<Battling>());
        }
        _currentWave = Mathf.Min(_currentWave + 1, _waves.Count - 1);
        return enemies;
    }
}
