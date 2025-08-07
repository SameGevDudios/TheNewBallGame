using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [Header("Object pooling")]
    [SerializeField] private List<Pool> _pools = new();

    [Header("Waves")]
    [SerializeField] private List<Wave> _waves = new();

    [Header("Player")]
    [SerializeField] private string _playerPoolTag;
    [SerializeField] private Vector3 _playerPosition;
    [SerializeField] private int _playerHealth, _playerDamage;
    [SerializeField] private float _applyDamageSpeed, _attackSpeed;

    [Header("Enemies")]

    [SerializeField] private int _enemyHealth, _enemyDamage;

    private void Awake()
    {
        // Instantiate pool manager
        IPoolManager poolManager = new PoolManager(_pools);
        Battling player = poolManager.InstantiateFromPool(_playerPoolTag, _playerPosition, Quaternion.identity)
            .GetComponent<Battling>();
        IWaveSpawner waveSpawner = 
            new WaveSpawner(poolManager, _waves, _enemyHealth, _enemyDamage, _applyDamageSpeed, _attackSpeed);
        IBattle battle = new Battle(waveSpawner, player);
        player.Init(battle, _playerHealth, _playerDamage, _applyDamageSpeed, _attackSpeed);

        // Start game
        battle.Attack();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_playerPosition, 0.1f);
    }
}
