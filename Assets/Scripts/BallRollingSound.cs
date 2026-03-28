using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BallRollingSound : MonoBehaviour
{
    [SerializeField] private float minSpeed = 0.1f;

    private AudioSource audioSource;
    private Rigidbody rb;
    private bool isGrounded = false;
    private int groundContactCount = 0;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        audioSource.loop = true;
        audioSource.playOnAwake = false;
    }

    private void Update()
    {
        float speed = rb.linearVelocity.magnitude;
        bool shouldPlay = isGrounded && speed > minSpeed;

        if (shouldPlay && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (!shouldPlay && audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        if (audioSource.isPlaying)
        {
            audioSource.volume = Mathf.Clamp01(speed / 10f) * 0.2f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        groundContactCount++;
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        groundContactCount--;
        if (groundContactCount <= 0)
        {
            groundContactCount = 0;
            isGrounded = false;
        }
    }

    public void StopSound()
    {
        audioSource.Stop();
        enabled = false;
    }

    public void EnableSound()
    {
        enabled = true;
    }
}
