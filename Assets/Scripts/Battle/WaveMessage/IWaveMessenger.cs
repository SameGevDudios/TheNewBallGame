using System.Collections.Generic;

public interface IWaveMessenger
{
    IBattle GetBattle();
    void SetBattle(IBattle battle);
    void SendMessage(Queue<Battling> enemies);
}
