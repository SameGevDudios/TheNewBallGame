using System.Collections.Generic;

public class BattleEvent : IBattle, IGameEvent
{
    private IEventCaller _eventCaller;
    private Battling _player, _currentEntity;
    private Queue<Battling> _enemies;
    private bool _playerTurn, _enemiesAlive = true;

    public BattleEvent(IEventCaller eventCaller, Battling player)
    {
        _eventCaller = eventCaller;
        _player = player;
    }

    public void Play()
    {
        _enemiesAlive = true;
        SetPlayerTurn();
        Attack();
    }

    public void Attack()
    {
        if (_enemiesAlive)
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
            _enemiesAlive = false;
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
