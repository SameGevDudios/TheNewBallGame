public class HealthUpgrade : Upgrade
{
    private IHealthUpgradable _upgradable;
    private int _amount;

    public HealthUpgrade(IHealthUpgradable healthUpgradable, IPurchasable purchasable, int cost, int costStep, int amount) : base(purchasable, cost, costStep)
    {
        _upgradable = healthUpgradable;
        _amount = amount;
    }

    protected override void ApplyUpgrade()
    {
        _upgradable.GetHealthUpgrade(_amount);
    }
}
