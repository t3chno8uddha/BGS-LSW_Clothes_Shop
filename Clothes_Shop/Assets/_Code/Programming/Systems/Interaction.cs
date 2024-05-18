using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    bool isInReach = false; // Whether or not the player is in interactible distance.

    public UnityEvent interactionEvent; // The event to call in case of an interaction.
    public AudioClip interactionSFX;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    void Update()
    {
        if (isInReach)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                interactionEvent.Invoke();

                if (interactionSFX)
                {
                    audioSource.PlayOneShot(interactionSFX);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        isInReach = true;
    }

    void OnTriggerExit2D (Collider2D collider)
    {
        isInReach = false;
    }
}
