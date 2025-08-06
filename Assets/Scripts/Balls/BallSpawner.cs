using UnityEngine;

public class BallSpawner
{
    private PoolManager _poolManager;
    public BallSpawner(PoolManager poolManager)
    {
        _poolManager = poolManager;
    }

    public void TouchedDoorAtPosition(Vector3 position, Vector3 velocity)
    {
        GameObject ball = SpawnBallAtPosition(position);
        ball.gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
    }

    public GameObject SpawnBallAtPosition(Vector3 position)
    {
        GameObject buffer = _poolManager.InstantiateFromPool("ball", position, Quaternion.identity);
        Ball ball = buffer.GetComponent<Ball>();
        ball.Instantiate(this);
        return buffer;
    }
}
