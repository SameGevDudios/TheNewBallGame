using System.Collections;
using UnityEngine;

public class Bow : Weapon
{
    [SerializeField] private GameObject _arrow;
    [SerializeField] private AnimationCurve _verticalVelocity, _horizontalVelocity;
    private float _attackDuration, _distance;
    private Transform _target;

    public override void Attack(float attackDuration)
    {
        _arrow.transform.position = transform.position;
        _attackDuration = attackDuration;
        StartCoroutine(MovingVertically());
        StartCoroutine(MovingHorizontally());
    }

    public override void LookAtTarget(Transform target)
    {
        _target = target;
        _distance = Vector3.Distance(transform.position, _target.position);
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private IEnumerator MovingVertically()
    {
        float currentTime = 0;
        float totalTime = _verticalVelocity.keys[_verticalVelocity.keys.Length - 1].time;
        while (currentTime < totalTime)
        {
            Debug.Log(_distance);
            Debug.Log(_verticalVelocity.Evaluate(currentTime) * _attackDuration / _distance);
            _arrow.transform.position = _arrow.transform.position + Vector3.up * _verticalVelocity.Evaluate(currentTime) * _attackDuration / _distance;
            currentTime += Time.deltaTime / _attackDuration * _distance;
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator MovingHorizontally()
    {
        float currentTime = 0;
        float totalTime = _verticalVelocity.keys[_verticalVelocity.keys.Length - 1].time;
        while (currentTime < totalTime)
        {
            _arrow.transform.position = _arrow.transform.position + Vector3.right * _verticalVelocity.Evaluate(currentTime) * _attackDuration / _distance;
            currentTime += Time.deltaTime / _attackDuration * _distance;
            yield return new WaitForEndOfFrame();
        }
    }
}
