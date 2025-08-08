using UnityEngine;
using TMPro;
using DG.Tweening;

public class HitTextUI
{
    private ISpawner _spawner;
    private Vector3 _offset = Vector3.back;
    private float _moveDistance, _moveDuration, _scaleDuration;

    public HitTextUI(ISpawner spawner, float moveDistance, float moveDuration, float scaleDuration)
    {
        _spawner = spawner;
        _moveDistance = moveDistance;
        _moveDuration = moveDuration;
        _scaleDuration = scaleDuration;
    }

    public void ShowHit(Vector3 actorPosition, int damage)
    {
        GameObject buffer = _spawner.Spawn(actorPosition + _offset);
        TMP_Text text = buffer.GetComponentInChildren<TMP_Text>();
        text.text = $"-{damage}";
        buffer.transform.localScale = Vector3.one;
        Sequence animation = DOTween.Sequence();
        animation
            .Append(buffer.transform.DOMoveY(buffer.transform.position.y + _moveDistance, _moveDuration))
            .Join(buffer.transform.DOScale(Vector3.zero, _scaleDuration).SetEase(Ease.Linear));
    }
}