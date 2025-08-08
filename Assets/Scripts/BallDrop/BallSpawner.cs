using UnityEngine;

public class BallSpawner : ISpawner
{
    private IPoolManager _poolManager;
    private string _ballTag;

    public BallSpawner(IPoolManager poolManager, string ballTag)
    {
        _poolManager = poolManager;
        _ballTag = ballTag;
    }

    public GameObject Spawn()
    {
        GameObject buffer = _poolManager.InstantiateFromPool(_ballTag, Vector3.zero, Quaternion.identity);
        IBall ball = buffer.GetComponent<IBall>();
        ball.Init(this);
        return buffer;
    }

    public GameObject Spawn(Vector3 position)
    {
        GameObject buffer = Spawn();
        buffer.transform.position = position;
        return buffer;
    }
}
