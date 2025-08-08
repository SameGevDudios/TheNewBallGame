using TMPro;

public class BallCountUI
{
    private TMP_Text _text;

    public BallCountUI(TMP_Text text)
    {
        _text = text;
    }

    public void UpdateText(int count)
    {
        _text.text = count.ToString();
    }
}
