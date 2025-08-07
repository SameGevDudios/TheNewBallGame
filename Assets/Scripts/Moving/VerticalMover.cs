using DG.Tweening;
using UnityEngine;

public class VerticalMover : IMover
{
    private Transform _movable;
    private float _moveDistance, _moveDuration;

    public VerticalMover(Transform movable, float moveDistance, float moveDuration)
    {
        _movable = movable;
        _moveDistance = moveDistance;
        _moveDuration = moveDuration;
    }

    public void Move()
    {
        _movable.DOMoveY(_movable.position.y + _moveDistance, _moveDuration);
        _moveDistance = -_moveDistance;
    }

    public void SetNewMovable(Transform movable)
    {
        _movable = movable;
    }
}
