using UnityEngine;
using UnityEngine.UI;

public class UpgradeSelector : MonoBehaviour, IGameEvent
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _damageButton, _healthButton, _speedButton, _closeButton;
    private IEventCaller _caller;
    private Upgrade _damageUpgrade, _healthUpgrade, _speedUpgrade;

    public void Init(IEventCaller caller, Upgrade damageUpgrade, Upgrade healthUpgrade, Upgrade speedUpgrade)
    {
        _caller = caller;
        _damageUpgrade = damageUpgrade;
        _healthUpgrade = healthUpgrade;
        _speedUpgrade = speedUpgrade;
        AssignButtonActions();
    }

    public void Play()
    {
        _panel.SetActive(true);
    }

    private void AssignButtonActions()
    {
        _damageButton.onClick.AddListener(() => _damageUpgrade.Buy());
        _healthButton.onClick.AddListener(() => _healthUpgrade.Buy());
        _speedButton.onClick.AddListener(() => _speedUpgrade.Buy());
        _closeButton.onClick.AddListener(() => ClosePanel());
    }

    private void ClosePanel()
    {
        _panel.SetActive(false);
        _caller.PlayNext();
    }
}
