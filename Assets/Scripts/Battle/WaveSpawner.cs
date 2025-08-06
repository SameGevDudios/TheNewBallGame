using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : IWaveSpawner
{
    private IPoolManager _poolManager;
    private List<Wave> _waves = new();
    private int _currentWave, _enemyBaseHeath, _enemyBaseDamage;
    private float _applyDamageTime, _attackTime;

    public WaveSpawner(IPoolManager poolmanager, List<Wave> waves, int enemyBaseHealth, int enemyBaseDamage, float applyDamageTime, float attackTime) 
    {
        _poolManager = poolmanager;
        _waves = waves;
        _enemyBaseHeath = enemyBaseHealth;
        _enemyBaseDamage = enemyBaseDamage;
        _applyDamageTime = applyDamageTime;
        _attackTime = attackTime;
    }

    public Queue<Battling> Spawn(IBattle sender)
    {
        Queue<Battling> enemies = new();
        int waveIndex = _currentWave % (_waves.Count - 1);
        foreach (Wave.Enemy enemy in _waves[waveIndex].Enemies) 
        {
            GameObject buffer = _poolManager.InstantiateFromPool(enemy.EnemyObject.name, enemy.Position, Quaternion.identity);
            enemies.Enqueue(buffer.GetComponent<Battling>());
        }
        InitEnemies(sender, enemies);
        _currentWave++;
        return enemies;
    }

    public void InitEnemies(IBattle battle, Queue<Battling> enemies)
    {
        int health = (int)(_enemyBaseHeath + _currentWave * 1.1f);
        int damage = (int)(_enemyBaseDamage + _currentWave * 1.1f);
        foreach(Battling enemy in enemies)
        {
            enemy.Init(battle, health, damage, _applyDamageTime, _attackTime);
        }
    }
}
