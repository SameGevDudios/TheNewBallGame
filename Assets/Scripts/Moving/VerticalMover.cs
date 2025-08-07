using DG.Tweening;
using UnityEngine;

public class VerticalMover : IMover
{
    private Transform _camera;
    private float _moveDistance, _moveDuration;

    public VerticalMover(Transform camera, float moveDistance, float moveDuration)
    {
        _camera = camera;
        _moveDistance = moveDistance;
        _moveDuration = moveDuration;
    }

    public void Move()
    {
        _camera.DOMoveY(_camera.position.y + _moveDistance, _moveDuration);
        _moveDistance = -_moveDistance;
    }
}
