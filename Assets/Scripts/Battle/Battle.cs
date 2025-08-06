using System.Collections.Generic;

public class Battle : IBattle
{
    private IWaveSpawner _waveSpawner;
    private Battling _player, _currentEntity;
    private Queue<Battling> _enemies;
    private bool _playerTurn;

    public Battle(IWaveSpawner waveSpawner, Battling player)
    {
        _waveSpawner = waveSpawner;
        _player = player;
        SetPlayerTurn();
        SpawnNewWave();
    }

    private void SetPlayerTurn()
    {
        _currentEntity = _player;
        _playerTurn = true;
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
            SetPlayerTurn();
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
            NextWave();
        }
    }

    private void NextWave()
    {

        SpawnNewWave();
        SetPlayerTurn();
        // HealPlayer();
    }

    private void SpawnNewWave()
    {
        _enemies = _waveSpawner.Spawn(this);
    }
}
