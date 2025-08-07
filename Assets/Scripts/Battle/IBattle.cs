using System.Collections.Generic;

public interface IBattle
{
    void Attack();
    void PlayerKilled();
    void EnemyKilled();
    void SetEnemies(Queue<Battling> enemies);
}
