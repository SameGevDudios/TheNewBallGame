using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : ISpawner
{
    private IPoolManager _poolManager;
    private IWaveMessenger _messenger;

    private HitTextUI _hitUI;

    private List<Wave> _waves = new();
    private int _currentWave, _enemyBaseHeath, _enemyBaseDamage, _addBallCount;
    private float _applyDamageTime, _attackTime;
    private float _currentOffset, _spawnOffset;

    public WaveSpawner(IPoolManager poolmanager, IWaveMessenger messenger,  List<Wave> waves, 
        int enemyBaseHealth, int enemyBaseDamage, int addBallCount, float applyDamageTime, float attackTime, float spawnOffset) 
    {
        _poolManager = poolmanager;
        _messenger = messenger;
        _waves = waves;
        _enemyBaseHeath = enemyBaseHealth;
        _enemyBaseDamage = enemyBaseDamage;
        _addBallCount = addBallCount;
        _applyDamageTime = applyDamageTime;
        _attackTime = attackTime;
        _spawnOffset = spawnOffset;
    }

    public void SetHitUI(HitTextUI hitIU)
    {
        _hitUI = hitIU;
    }

    public GameObject Spawn()
    {
        Queue<Battling> enemies = new();
        int waveIndex = _currentWave % (_waves.Count - 1);
        _currentOffset += _spawnOffset;
        foreach (Wave.Enemy enemy in _waves[waveIndex].Enemies) 
        {
            Vector3 spawnPosition = enemy.Position + Vector3.right * _currentOffset;
            GameObject buffer = _poolManager.InstantiateFromPool(enemy.EnemyObject.name, spawnPosition, Quaternion.identity);
            enemies.Enqueue(buffer.GetComponent<Battling>());
        }
        InitEnemies(_messenger.GetBattle(), enemies);
        _currentWave++;
        _messenger.SendMessage(enemies);
        return null;
    }
    public GameObject Spawn(Vector3 position)
    {
        GameObject buffer = Spawn();
        buffer.transform.position = position;
        return buffer;
    }

    public void InitEnemies(IBattle battle, Queue<Battling> enemies)
    {
        int health = (int)(_enemyBaseHeath + _currentWave * 1.1f);
        int damage = (int)(_enemyBaseDamage + _currentWave * 1.1f);
        foreach(RangeEnemy enemy in enemies)
        {
            enemy.Init(battle, _hitUI, health, damage, _applyDamageTime, _attackTime);
            enemy.SetBallCount(_addBallCount);
        }
    }
}
