using UnityEngine;

public interface ISpawner 
{
    GameObject Spawn();
    GameObject Spawn(Vector3 position);
}
