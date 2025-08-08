using UnityEngine;

public class Sword : Weapon
{
    [SerializeField] private Animator _animator;

    public override void Attack(float attackDuration)
    {
        _animator.SetTrigger("Attack");
        AnimationClip currentClip =
            _animator.GetCurrentAnimatorClipInfo(0)[0].clip;
        _animator.speed = currentClip.length / attackDuration;
        Invoke("EndAttackAnimation", attackDuration);
    }

    private void EndAttackAnimation()
    {
        _animator.speed = 1f;
    }

    public override void LookAtTarget(Transform target)
    {

    }
}
