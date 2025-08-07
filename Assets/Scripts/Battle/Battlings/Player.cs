using UnityEngine;

public class Player : Battling
{
    [SerializeField] private Transform _camera;
    protected override void Death()
    {
        base.Death();
        _battle.PlayerKilled();
    }

    public Transform GetCamera()
    {
        return _camera;
    }
}
