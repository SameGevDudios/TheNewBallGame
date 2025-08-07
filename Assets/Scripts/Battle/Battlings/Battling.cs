using UnityEngine;
using UnityEngine.UI;

public abstract class Battling : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private Weapon _weapon;
    private HealthBarUI _healthBarUI;
    protected IBattle _battle;
    private Battling _target;

    protected int _maxHealth, _health, _damage;
    protected float _applyDamageTime, _attackTime;

    public void Init(IBattle battle, int health, int damage, float applyDamageTime, float attackTime)
    {
        _battle = battle;
        _maxHealth = health;
        _health = _maxHealth;
        _damage = damage;
        _applyDamageTime = applyDamageTime;
        _attackTime = attackTime;
        _healthBarUI = new HealthBarUI(_healthBar);
    }

    public virtual void Attack(Battling target)
    {
        _target = target;
        _weapon.LookAtTarget(_target.transform);
        _weapon.Attack(_applyDamageTime);
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
        _healthBarUI.UpdateBar(_health, _maxHealth);
        if(_health <= 0)
        {
            Death();
        }
    }

    public void Heal()
    {
        _health = _maxHealth;
        _healthBarUI.UpdateBar(_health, _maxHealth);
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
