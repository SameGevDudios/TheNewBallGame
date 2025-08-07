public class SpeedUpgrade : Upgrade
{
    private ISpeedUpgradable _upgradable;
    private float _amount;

    public SpeedUpgrade(ISpeedUpgradable speedUpgradable, IPurchasable purchasable, int cost, int costStep, float amount) : base(purchasable, cost, costStep)
    {
        _upgradable = speedUpgradable;
        _amount = amount;
    }

    protected override void ApplyUpgrade()
    {
        _upgradable.GetSpeedUpgrade(_amount);
    }
}
