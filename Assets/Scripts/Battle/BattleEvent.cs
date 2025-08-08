using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BattleEvent : IBattle, IGameEvent
{
    private IEventCaller _eventCaller;

    private GameObject _gameOverPanel;
    private Battling _player, _currentEntity;
    private Queue<Battling> _enemies;
    private bool _playerTurn, _canAttack = true;

    public BattleEvent(IEventCaller eventCaller, GameObject gameOverPanel, Battling player)
    {
        _gameOverPanel = gameOverPanel;
        _eventCaller = eventCaller;
        _player = player;
    }

    public void Play()
    {
        _canAttack = true;
        _player.Heal();
        SetPlayerTurn();
        Attack();
    }

    public void Attack()
    {
        if (_canAttack)
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
        _gameOverPanel.SetActive(true);
        _canAttack = false;
    }

    public async Task EnemyKilled()
    {
        _enemies.Dequeue();
        if(_enemies.Count == 0)
        {
            _canAttack = false;
            await _eventCaller.PlayNext();
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
