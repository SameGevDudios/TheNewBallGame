using UnityEngine;

public abstract class Battling : MonoBehaviour
{
    private IBattle _battle;
    private int _health, _damage;
    private float _applyDamageTime, _attackTime;

    public void Instantiate(IBattle battle, int health, int damage, float applyDamageTime, float attackTime)
    {
        _battle = battle;
        _health = health;
        _damage = damage;
        _applyDamageTime = applyDamageTime;
        _attackTime = attackTime;
    }

    public virtual void Attack()
    {
        print("I attacked!");
        Invoke("ApplyDamage", _applyDamageTime);
        Invoke("FinishAttack", _attackTime);
    }

    public void ApplyDamage()
    {
        _battle.ApplyDamage(_damage);
    }

    public void GetDamage(int damage)
    {
        _health -= damage;
        // UpdateUI
        if(_health < 0 )
        {
            Death();
        }
    }

    protected virtual void Death()
    {
        print("I died!");
    }

    private void FinishAttack()
    {
        _battle.Attack();
    }
}
