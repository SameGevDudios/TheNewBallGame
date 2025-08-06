public class Player : Battling
{
    public override void Attack(Battling target)
    {
        print("Player attacked!");
        base.Attack(target);
    }
}
