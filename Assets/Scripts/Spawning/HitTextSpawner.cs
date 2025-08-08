using UnityEngine;

public class HitTextSpawner : ISpawner
{
    private IPoolManager _poolManager;
    private string _textTag;

    public HitTextSpawner(IPoolManager poolManager,string textTag)
    {
        _poolManager = poolManager;
        _textTag = textTag;
    }

    public GameObject Spawn()
    {
        return _poolManager.InstantiateFromPool(_textTag, Vector3.zero, Quaternion.identity);
    }

    public GameObject Spawn(Vector3 position)
    {
        GameObject buffer = Spawn();
        buffer.transform.position = position;
        return buffer;
    }
}
