using DG.Tweening;
using UnityEngine;

public class MeleeEnemy : RangeEnemy
{
    private Vector3 _moveOffset = new Vector3(0.5f, 0, 0);
    private int _stepsToPlayer = 3, _stepsMade;
    private float _distance;

    protected override void BeginAttack()
    {
        SetDistance();
        if(_stepsMade < _stepsToPlayer)
        {
            Move();
            _stepsMade++;
        }
        else
        {
            base.BeginAttack();
        }
    }

    private void SetDistance()
    {
        if(_distance == 0)
        {
            _distance = Vector3.Distance(transform.position + _moveOffset, _target.transform.position);
        }
    }

    private void Move()
    {
        transform.DOMoveX(transform.position.x + _moveOffset.x - _distance / _stepsToPlayer, _applyDamageTime);
    }
}
