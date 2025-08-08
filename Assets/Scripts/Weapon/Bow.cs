using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Bow : Weapon
{
    [SerializeField] private GameObject _arrow;
    [SerializeField] private AnimationCurve _verticalVelocity, _horizontalVelocity;
    private Transform _target;
    private Vector3 _targetOffset = new Vector3(0, .65f, 0);

    public override void Attack(float attackDuration)
    {
        _arrow.transform.position = transform.position;
        StartCoroutine(MoveArrow(attackDuration));
    }

    public override void LookAtTarget(Transform target)
    {
        _target = target;
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private IEnumerator MoveArrow(float duration)
    {
        _arrow.transform.position = transform.position;
        _arrow.SetActive(true);
        Vector3 endValue = _target.position  + _targetOffset;
        _arrow.transform.DOMove(endValue, duration);
        yield return new WaitForSeconds(duration);
        _arrow.SetActive(false);
    }
}