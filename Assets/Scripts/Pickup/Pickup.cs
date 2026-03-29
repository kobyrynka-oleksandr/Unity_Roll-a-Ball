using UnityEngine;

public class Pickup : MonoBehaviour
{
    private AudioSource pickUpSound;
    void Start()
    {
        pickUpSound = GetComponent<AudioSource>();
    }

    public void PlayPickupSoundAndParticle()
    {
        if (pickUpSound != null)
        {
            GameManager.Instance.SpawnPickupEffect(transform.position);
            AudioSource.PlayClipAtPoint(pickUpSound.clip, transform.position, pickUpSound.volume);
        }
    }
}
