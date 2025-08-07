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

    [Header("Enemies")]
    [SerializeField] private int _enemyHealth, _enemyDamage;

    [Header("Battle speed")]
    [SerializeField] private float _applyDamageSpeed;
    [SerializeField] private float _attackSpeed;

    [Header("LevelChange")]
    [SerializeField] private float _moveDistance;
    [SerializeField] private float _moveDuration;

    private void Awake()
    {
        // Instantiate pool manager
        IPoolManager poolManager = new PoolManager(_pools);
        IWaveSpawner waveSpawner = 
            new WaveSpawner(poolManager, _waves, _enemyHealth, _enemyDamage, _applyDamageSpeed, _attackSpeed, _moveDistance);
        IBackgroundSpawner backgroundSpawner = new BackgroundSpawner(poolManager, _moveDistance);
        Battling player = poolManager.InstantiateFromPool(_playerPoolTag, _playerPosition, Quaternion.identity)
            .GetComponent<Battling>();
        IPlayerMover playerMover = new PlayerMover(player.transform, _moveDistance, _moveDuration);
        IGameEvent changer = new LevelChanger(playerMover, backgroundSpawner);
        IBattle battle = new Battle(waveSpawner, changer, player);
        player.Init(battle, _playerHealth, _playerDamage, _applyDamageSpeed, _attackSpeed);

        // Start game
        IGameEvent battleEvent = (IGameEvent)battle;
        battleEvent.Play();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_playerPosition, 0.1f);
    }
}
