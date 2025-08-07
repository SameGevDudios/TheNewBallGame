using UnityEngine;

public abstract class Battling : MonoBehaviour
{
    protected IBattle _battle;
    private Battling _target;

    private int _health, _damage;
    private float _applyDamageTime, _attackTime;

    public void Init(IBattle battle, int health, int damage, float applyDamageTime, float attackTime)
    {
        _battle = battle;
        _health = health;
        _damage = damage;
        _applyDamageTime = applyDamageTime;
        _attackTime = attackTime;
    }

    public virtual void Attack(Battling target)
    {
        _target = target;
        Invoke("ApplyDamage", _applyDamageTime);
        Invoke("FinishAttack", _attackTime);
    }

    public void ApplyDamage()
    {
        _target.GetDamage(_damage);
    }

    public void GetDamage(int damage)
    {
        _health -= damage;
        // UpdateUI
        if(_health <= 0)
        {
            Death();
        }
    }

    protected virtual void Death()
    {
        gameObject.SetActive(false);
    }

    private void FinishAttack()
    {
        _battle.Attack();
    }
}
