using UnityEngine;

public interface IPoolManager
{
    GameObject InstantiateFromPool(string tag, Vector3 transform, Quaternion quaternion);
}
