public abstract class Upgrade
{
    private IPurchasable _purchasable;
    private int _cost, _costStep;

    public Upgrade(IPurchasable purchasable, int cost, int costStep)
    {
        _purchasable = purchasable;
        _cost = cost;
        _costStep = costStep;
    }

    public void Buy()
    {
        if (_purchasable.Buy(_cost))
        {
            ApplyUpgrade();
            _cost += _costStep;
        }
    }

    protected abstract void ApplyUpgrade();
}
