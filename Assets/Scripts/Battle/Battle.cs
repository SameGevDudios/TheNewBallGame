using System.Collections.Generic;

public class Battle : IBattle, IGameEvent
{
    private IEventCaller _eventCaller;
    private Battling _player, _currentEntity;
    private Queue<Battling> _enemies;
    private bool _playerTurn;

    public Battle(IEventCaller eventCaller, Battling player)
    {
        _eventCaller = eventCaller;
        _player = player;
    }

    public void Play()
    {
        SetPlayerTurn();
        Attack();
    }

    public void Attack()
    {
        if (_playerTurn)
        {
            _currentEntity.Attack(_enemies.Peek());
            _playerTurn = false;
        }
        else
        {
            GetNextEnemy();
            _currentEntity.Attack(_player);
            SetPlayerTurn();
        }
    }

    public void PlayerKilled()
    {
        // Game over
    }

    public void EnemyKilled()
    {
        _enemies.Dequeue();
        if(_enemies.Count == 0)
        {
            _eventCaller.PlayNext();
        }
    }

    public void SetEnemies(Queue<Battling> enemies) 
    {
        _enemies = enemies;
    }

    private void SetPlayerTurn()
    {
        _currentEntity = _player;
        _playerTurn = true;
    }

    private void GetNextEnemy()
    {
        _currentEntity = _enemies.Dequeue();
        _enemies.Enqueue(_currentEntity);
    }
}
