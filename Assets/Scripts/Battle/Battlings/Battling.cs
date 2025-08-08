using UnityEngine;
using UnityEngine.UI;

public abstract class Battling : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private Weapon _weapon;

    private HealthBarUI _healthBarUI;
    protected Battling _target;

    protected IBattle _battle;

    private HitTextUI _hitUI;

    protected int _maxHealth, _health, _damage;
    protected float _applyDamageTime, _attackTime;

    public virtual void Init(IBattle battle, HitTextUI textUI, int health, int damage, float applyDamageTime, float attackTime)
    {
        _battle = battle;
        _hitUI = textUI;
        _maxHealth = health;
        _health = _maxHealth;
        _damage = damage;
        _applyDamageTime = applyDamageTime;
        _attackTime = attackTime;
        _healthBarUI = new HealthBarUI(_healthBar);
    }

    public virtual void Attack(Battling target)
    {
        SetTarget(target);
        BeginAttack();
        Invoke("FinishAttack", _attackTime);
    }

    protected void SetTarget(Battling target)
    {
        _target = target;
    }

    protected virtual void BeginAttack()
    {
        _weapon.LookAtTarget(_target.transform);
        _weapon.Attack(_applyDamageTime);
        Invoke("ApplyDamage", _applyDamageTime);
    }

    public void ApplyDamage()
    {
        _target.GetDamage(_damage);
    }

    public void GetDamage(int damage)
    {
        _health -= damage;

        _healthBarUI.UpdateBar(_health, _maxHealth);
        _hitUI.ShowHit(transform.position, _damage);
        
        if (_health <= 0)
        {
            Death();
        }
    }

    protected virtual void Death()
    {
        gameObject.SetActive(false);
    }
    public void Heal()
    {
        _health = _maxHealth;
        _healthBarUI.UpdateBar(_health, _maxHealth);
    }

    private void FinishAttack()
    {
        _battle.Attack();
    }
}
