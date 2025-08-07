using System.Collections.Generic;

public class WaveMessenger : IWaveMessenger
{
    private IBattle _battle;

    public IBattle GetBattle()
    {
        return _battle;
    }
    public void SetBattle(IBattle battle)
    {
        _battle = battle;
    }
    public void SendMessage(Queue<Battling> enemies)
    {
        _battle.SetEnemies(enemies);
    }
}
