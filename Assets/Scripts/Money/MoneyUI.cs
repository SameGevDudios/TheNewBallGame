using TMPro;

public class MoneyUI
{
    private TMP_Text _text;

    public MoneyUI(TMP_Text text)
    {
        _text = text;
    }

    public void UpdateText(int money)
    {
        _text.text = money.ToString();
    }
}
