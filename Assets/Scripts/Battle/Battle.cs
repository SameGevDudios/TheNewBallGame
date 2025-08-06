using System.Collections.Generic;
using UnityEngine;

public class Battle : IBattle
{
    private IWaveSpawner _waveSpawner;
    private Battling _player, _currentEntity;
    private Queue<Battling> _enemies;
    private bool _playerTurn = true;
    private int _enemiesAlive;

    public Battle(IWaveSpawner waveSpawner, Battling player, Queue<Battling> enemies)
    {
        _waveSpawner = waveSpawner;
        _player = player;
        _enemies = enemies;
        _currentEntity = _player;

    }

    public void Attack()
    {
        _currentEntity.Attack();
        if (_playerTurn)
        {
            _playerTurn = false;
            GetNextEnemy();
        }
        else
        {
            _playerTurn = true;
        }
    }
    
    private void GetNextEnemy()
    {
        _currentEntity = _enemies.Dequeue();
        _enemies.Enqueue(_currentEntity);
    }

    public void ApplyDamage(int damage)
    {
        if (_playerTurn)
        {
            _enemies.Peek().GetDamage(damage);
        }
        else
        {
            _player.GetDamage(damage);
        }
    }

    public void EnemyKilled()
    {
        _enemiesAlive--;
        if(_enemiesAlive <= 0)
        {
            SpawnNewWave();
        }
    }

    private void SpawnNewWave()
    {
        _waveSpawner.Spawn(out _enemiesAlive);
    }
}
