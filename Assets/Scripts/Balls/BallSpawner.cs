using UnityEngine;

public class BallSpawner
{
    private IPoolManager _poolManager;
    public BallSpawner(IPoolManager poolManager)
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
        IBall ball = buffer.GetComponent<IBall>();
        ball.Instantiate(this);
        return buffer;
    }
}
