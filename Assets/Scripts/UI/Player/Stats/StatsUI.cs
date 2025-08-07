using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _damageText, _speedText;
    private int _speed;

    public void UpdateDamageText(int damage)
    {
        _damageText.text = damage.ToString();
    }

    public void UpdateSpeedText() 
    {
        _speed++;
        _speedText.text = _speed.ToString();
    }
}
