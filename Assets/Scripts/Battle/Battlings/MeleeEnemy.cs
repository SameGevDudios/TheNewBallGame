public class MeleeEnemy : Battling
{
    protected override void Death()
    {
        base.Death();
        _battle.EnemyKilled();
    }
}
