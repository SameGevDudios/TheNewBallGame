using UnityEngine;

public class Player : Battling, IDamageUpgradable, IHealthUpgradable, ISpeedUpgradable
{
    [SerializeField] private Transform _camera;
    [SerializeField] private StatsUI _statsUI;

    protected override void Death()
    {
        _battle.PlayerKilled();
    }

    public Transform GetCamera() 
    { 
        return _camera;
    }

    public void GetDamageUpgrade(int amount)
    {
        _damage += amount;
        _statsUI.UpdateDamageText(_damage);
    }

    public void GetHealthUpgrade(int amount)
    {
        _maxHealth += amount;
    }
    
    public void GetSpeedUpgrade(float amount)
    {
        _applyDamageTime *= amount;
        _attackTime *= amount;
        _statsUI.UpdateSpeedText();
    }

}
