using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI
{
    private Image _bar;

    public HealthBarUI(Image bar)
    {
        _bar = bar;
    }

    public void UpdateBar(int health, int maxHealth)
    {
        _bar.fillAmount = Mathf.Max(0, (float)health / maxHealth);
    }
}
