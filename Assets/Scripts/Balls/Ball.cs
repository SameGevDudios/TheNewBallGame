using UnityEngine;

public class Ball : MonoBehaviour, IBall
{
    private BallSpawner _spawner;
    private Rigidbody2D _rigidbody;
    private float _cloneCooldown = 0.1f;
    private float _cloneOffset = 0.03f;
    private bool _canClone;

    public void Instantiate(BallSpawner ballSpawner)
    {
        _spawner = ballSpawner;
        Invoke("AllowClone", _cloneCooldown);
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void AllowClone()
    {
        _canClone = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CloneDoor"))
        {
            if (_canClone)
            {
                CloneDoor door = collision.GetComponent<CloneDoor>();
                if (door == null)
                {
                    Debug.LogError($"Component CloneDoor required at object {collision.gameObject.name}.");
                    return;
                }
                for (int i = 0; i < door.Multilplier - 1; i++)
                {
                    _spawner.TouchedDoorAtPosition(transform.position, _rigidbody.velocity);
                    transform.position += Vector3.right * _cloneOffset;
                }
            }
        }
    }
}
