using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    private Dictionary<string, Queue<GameObject>> _poolDictionary = new();
    private List<Pool> _pools;
    private GameObject _poolHandler;

    public PoolManager(List<Pool> pools)
    {
        _poolHandler = new GameObject("PoolHandler");
        _pools = pools;
        foreach (Pool pool in pools)
        {
            _poolDictionary.Add(pool.name, new Queue<GameObject>());
            InstantiateNewObject(pool.name);
        }
    }
    
    private void InstantiateNewObject(string tag)
    {
        Pool pool = FindByName(_pools, tag);
        GameObject buffer = GameObject.Instantiate(pool.Object, _poolHandler.transform);
        buffer.SetActive(false);
        _poolDictionary[tag].Enqueue(buffer);
    }

    public GameObject InstantiateFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!_poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning($"Pool with tag {tag} does not exist.");
            return null;
        }
        GameObject buffer = _poolDictionary[tag].Dequeue();
        buffer.SetActive(true);
        buffer.transform.position = position;
        buffer.transform.rotation = rotation;
        _poolDictionary[tag].Enqueue(buffer);
        return buffer;
    }

    private static Pool FindByName(List<Pool> pools, string name)
    {
        return pools.Find(x => x.name == name);
    }
}
