using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI
{
    private TMP_Text _text;
    private Image _bar;

    public HealthUI(TMP_Text text,Image bar)
    {
        _text = text;
        _bar = bar;
    }

    public void UpdateHealth(int health, int maxHealth)
    {
        _text.text = health.ToString();
        _bar.fillAmount = Mathf.Max(0, (float)health / maxHealth);
    }
}
