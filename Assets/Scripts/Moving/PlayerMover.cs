using DG.Tweening;
using UnityEngine;

public class PlayerMover : IMover
{
    private Transform _player;
    private float _moveDistance, _moveDuration;

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

    public void SetNewMovable(Transform newMovable)
    {
        _player = newMovable;
    }
}
