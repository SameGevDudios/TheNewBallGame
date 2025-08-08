public class RangeEnemy : Battling
{
    private int _ballAddOnDeath;

    public void SetBallCount(int count)
    {
        _ballAddOnDeath = count;
    }

    protected override void Death()
    {
        BallEvent.Instance.AddBallCount(_ballAddOnDeath);
        _battle.EnemyKilled();
        base.Death();
    }
}
