using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody rb;
    private Vector2 movementInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementInput.x, 0f, movementInput.y);
        rb.AddForce(movement * speed * Time.fixedDeltaTime);
    }

    public void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Pickup>(out Pickup pickup))
        {
            pickup.PlayPickupSoundAndParticle();
            pickup.gameObject.SetActive(false);
            GameEvents.OnPickupCollectedEvent();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("KillZone"))
        {
            GameEvents.OnPlayerDiedEvent();
        }
    }
}
