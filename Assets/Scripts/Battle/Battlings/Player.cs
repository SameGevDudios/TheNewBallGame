using UnityEngine;

public class Player : Battling, IDamageUpgradable, IHealthUpgradable, ISpeedUpgradable
{
    [SerializeField] private Transform _camera;
    protected override void Death()
    {
        base.Death();
        _battle.PlayerKilled();
    }

    public Transform GetCamera() 
    { 
        return _camera; 
    }

    public void GetDamageUpgrade(int amount)
    {
        _damage += amount;
    }

    public void GetHealthUpgrade(int amount)
    {
        _maxHealth += amount;
    }
    
    public void GetSpeedUpgrade(float amount)
    {
        _applyDamageTime *= amount;
        _attackTime *= amount;
    }
}
