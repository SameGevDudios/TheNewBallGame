using UnityEngine;

[CreateAssetMenu(fileName = "NewPool", menuName = "ObjectPooling/NewPool")]
public class Pool : ScriptableObject
{
    public GameObject Object;
    public int Size = 1;
}
