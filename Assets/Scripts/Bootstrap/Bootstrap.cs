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

    [Header("Level change")]
    [SerializeField] private float _playerMoveDistance;
    [SerializeField] private float _playerMoveDuration;

    [Header("Maze event")]
    [SerializeField] private int _mazePrefabCount;
    [SerializeField] private float _cameraMoveDistance;
    [SerializeField] private float _mazeMoveDistance;
    [SerializeField] private float _mazeEventMoveDuration;

    [Header("Ball event")]
    [SerializeField] private string _ballPoolTag;
    [SerializeField] private string _ballEventPoolTag;
    [SerializeField] private float _ballSpawnDelay, _ballSpawnPositionY;

    [Header("Event delay")]
    [SerializeField] private float _beforeEventDelay;
    [SerializeField] private float _afterEventDelay;

    private void Awake()
    {
        // Instantiate pool manager
        IPoolManager poolManager = new PoolManager(_pools);

        // Instantiate player
        Battling player = poolManager.InstantiateFromPool(_playerPoolTag, _playerPosition, Quaternion.identity)
            .GetComponent<Player>();
        Transform camera = ((Player)player).GetCamera();

        // Instantiave wave messenger
        IWaveMessenger messenger = new WaveMessenger();

        // Instantiate spawners
        ISpawner waveSpawner = 
            new WaveSpawner(poolManager, messenger, _waves, _enemyHealth, _enemyDamage, _applyDamageSpeed, _attackSpeed, _playerMoveDistance);
        ISpawner backgroundSpawner = new BackgroundSpawner(poolManager, _playerMoveDistance);
        ISpawner mazeSpawner = new MazeSpawner(poolManager, camera.transform, _mazeMoveDistance, _mazePrefabCount);
        ISpawner ballSpawner = new BallSpawner(poolManager, _ballPoolTag);

        // Instantiate event caller
        IEventCaller eventCaller = new EventCaller(_beforeEventDelay, _afterEventDelay);

        // Instantiate movers
        IMover playerMover = new PlayerMover(player.transform, _playerMoveDistance, _playerMoveDuration);
        IMover cameraMover = new VerticalMover(camera, _cameraMoveDistance, _mazeEventMoveDuration);
        IMover mazeMover = new VerticalMover(null, _mazeMoveDistance, _mazeEventMoveDuration);

        // Instantiate battle
        IBattle battle = new BattleEvent(eventCaller, player);

        // Instantiate money storage
        IBalance moneyBalance = new MoneyStorage();
        IPurchasable purchasable = (IPurchasable)moneyBalance;

        // Instantiate events
        IGameEvent changer = new LevelChangeEvent(playerMover, backgroundSpawner, waveSpawner, eventCaller);
        IGameEvent battleEvent = (IGameEvent)battle;
        IGameEvent mazeEvent = new MazeEvent(mazeSpawner, cameraMover, mazeMover, eventCaller);
        BallEvent ballEvent = poolManager.InstantiateFromPool(_ballEventPoolTag, Vector3.zero, Quaternion.identity).GetComponent<BallEvent>();
        ballEvent.Init(ballSpawner, eventCaller, mazeEvent, moneyBalance, _ballSpawnDelay, _ballSpawnPositionY);

        // Add events to queue
        eventCaller.Add(changer);
        eventCaller.Add(battleEvent);
        eventCaller.Add(mazeEvent);
        eventCaller.Add(ballEvent);

        // Start game
        messenger.SetBattle(battle);
        player.Init(battle, _playerHealth, _playerDamage, _applyDamageSpeed, _attackSpeed);
        eventCaller.PlayNext();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_playerPosition, 0.1f);
    }
}
