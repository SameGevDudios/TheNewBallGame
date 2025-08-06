using DG.Tweening;
using UnityEngine;

public class PlayerMover : IPlayerMover
{
    private Transform _player;
    private float _moveDistance;
    private float _moveDuration;

    public PlayerMover(Transform player, float moveDistance, float moveDuration)
    {
        _player = player;
        _moveDistance = moveDistance;
        _moveDuration = moveDuration;
    }

    public void Move()
    {
        _player.DOMoveX(_player.position.x + _moveDistance, _moveDuration);
    }
}
