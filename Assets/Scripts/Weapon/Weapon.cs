using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public abstract void Attack(float attackDuration);
    public abstract void LookAtTarget(Transform target);
}
