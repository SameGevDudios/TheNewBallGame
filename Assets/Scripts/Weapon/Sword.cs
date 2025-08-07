using System.Collections;
using UnityEngine;

public class Sword : Weapon
{
    [SerializeField] private AnimationCurve _verticalVelocity, _horizontalVelocity;
    private float _attackDuration;

    public override void Attack(float attackDuration)
    {
        _attackDuration = attackDuration;
        StartCoroutine(MovingVertically());
        StartCoroutine(MovingHorizontally());
    }

    public override void LookAtTarget(Transform target)
    {

    }

    private IEnumerator MovingVertically()
    {
        float currentTime = 0;
        float totalTime = _verticalVelocity.keys[_verticalVelocity.keys.Length - 1].time;
        while (currentTime < totalTime)
        {
            transform.position = transform.position + Vector3.up * _verticalVelocity.Evaluate(currentTime) * _attackDuration;
            currentTime += Time.deltaTime / _attackDuration;
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator MovingHorizontally()
    {
        float currentTime = 0;
        float totalTime = _verticalVelocity.keys[_verticalVelocity.keys.Length - 1].time;
        while (currentTime < totalTime)
        {
            transform.position = transform.position + Vector3.right * _verticalVelocity.Evaluate(currentTime) * _attackDuration;
            currentTime += Time.deltaTime / _attackDuration;
            yield return new WaitForEndOfFrame();
        }
    }
}
