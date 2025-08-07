public class MoneyStorage : IBalance, IPurchasable
{
    private MoneyUI _moneyUI;
    private int _money;

    public MoneyStorage(MoneyUI moneyUI)
    {
        _moneyUI = moneyUI;
        _moneyUI.UpdateText(_money);
    }

    public void Add()
    {
        _money++;
        _moneyUI.UpdateText(_money);
    }

    public bool Buy(int cost)
    {
        if(_money >= cost)
        {
            _money -= cost;
            _moneyUI.UpdateText(_money);
            return true;
        }
        return false;
    }
}
