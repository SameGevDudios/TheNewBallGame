using System.Collections.Generic;

public class Battle : IBattle
{
    private IWaveSpawner _waveSpawner;
    private Battling _player, _currentEntity;
    private Queue<Battling> _enemies;
    private bool _playerTurn = true;

    public Battle(IWaveSpawner waveSpawner, Battling player)
    {
        _waveSpawner = waveSpawner;
        _player = player;
        _currentEntity = _player;
        SpawnNewWave();
    }

    public void Attack()
    {
        if (_playerTurn)
        {
            _currentEntity.Attack(_enemies.Peek());
            GetNextEnemy();
            _playerTurn = false;
        }
        else
        {
            _currentEntity.Attack(_player);
            _currentEntity = _player;
            _playerTurn = true;
        }
    }
    
    private void GetNextEnemy()
    {
        _currentEntity = _enemies.Dequeue();
        _enemies.Enqueue(_currentEntity);
    }

    public void PlayerKilled()
    {

    }

    public void EnemyKilled()
    {
        _enemies.Dequeue();
        if(_enemies.Count == 0)
        {
            SpawnNewWave();
        }
    }

    private void SpawnNewWave()
    {
        _enemies = _waveSpawner.Spawn(this);
    }
}
