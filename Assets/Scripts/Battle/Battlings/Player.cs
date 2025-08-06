public class Player : Battling
{
    protected override void Death()
    {
        base.Death();
        _battle.PlayerKilled();
    }
}
