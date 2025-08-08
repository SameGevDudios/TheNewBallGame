using UnityEngine;
using UnityEngine.EventSystems;

public class BallEvent : MonoBehaviour, IGameEvent
{
    private ISpawner _ballSpawner;
    private IEventCaller _eventCaller;
    private IGameEvent _mazeEvent;
    private IBalance _balance;

    private BallCountUI _ui;

    private Vector3 _touchPosition;
    private float _spawnDelay, _spawnPositionY;
    private bool _canSpawn;
    private int _startBallCount, _ballCount;

    #region Singleton
    public static BallEvent Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public void Init(ISpawner ballSpawner, IEventCaller eventCaller, IGameEvent mazeEvent, 
        IBalance balance, BallCountUI ballUI, float spawnDelay, float spawnPositionY)
    {
        _ballSpawner = ballSpawner;
        _eventCaller = eventCaller;
        _mazeEvent = mazeEvent;
        _balance = balance;
        
        _ui = ballUI;

        _spawnDelay = spawnDelay;
        _spawnPositionY = spawnPositionY;

        UpdateUI();
    }

    public void Play()
    {
        ResetCooldown();
        _ballCount = _startBallCount;
    }

    public void AddBallCount(int amout)
    {
        _startBallCount += amout;
        UpdateUI();
    }

    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        if (_canSpawn && _startBallCount > 0)
        {
            if (Input.GetMouseButton(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    _canSpawn = false;
                    _startBallCount--;
                    UpdateUI();
                    UpdateTouchPosition();
                    SpawnBall();
                    Invoke("ResetCooldown", _spawnDelay);
                }
            }
        }
    }
    
    private void UpdateUI()
    {
        _ui.UpdateText(_startBallCount);
    }

    private void UpdateTouchPosition()
    {
        _touchPosition = new Vector3(
            Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            _spawnPositionY,
            0);
    }

    private void SpawnBall()
    {
        GameObject ball = _ballSpawner.Spawn();
        ball.transform.position = _touchPosition;
    }

    private void ResetCooldown()
    {
        _canSpawn = true;
    }

    public void AddBall()
    {
        _ballCount++;
    }

    public void BallCaught()
    {
        _balance.Add();
        BallGone();
    }

    public void BallGone()
    {
        _ballCount--;
        if (_ballCount == 0)
        {
            _canSpawn = false;
            _mazeEvent.Play();
            _eventCaller.PlayNext();
        }
    }
}
