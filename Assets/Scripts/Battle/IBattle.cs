using System.Collections.Generic;
using System.Threading.Tasks;

public interface IBattle
{
    void Attack();
    void PlayerKilled();
    Task EnemyKilled();
    void SetEnemies(Queue<Battling> enemies);
}
