public class DamageUpgrade : Upgrade
{
    private IDamageUpgradable _upgradable;
    private int _amount;

    public DamageUpgrade(IDamageUpgradable damageUpgradable, IPurchasable purchasable, int cost, int costStep, int upgradeAmount) : base(purchasable, cost, costStep)
    {
        _upgradable = damageUpgradable;
        _amount = upgradeAmount;
    }

    protected override void ApplyUpgrade()
    {
        _upgradable.GetDamageUpgrade(_amount);
    }
}
