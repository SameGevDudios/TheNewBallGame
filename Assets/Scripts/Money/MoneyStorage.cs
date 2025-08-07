public class MoneyStorage : IBalance, IPurchasable
{
    private int _money;

    public void Add()
    {
        _money++;
    }

    public bool Buy(int cost)
    {
        if(_money >= cost)
        {
            _money -= cost;
            return true;
        }
        return false;
    }
}
