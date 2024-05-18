using UnityEngine;

public class ClothesHanger : MonoBehaviour
{
    public Clothing clothes; // Clothing item on the hanger.
    
    PlayerCharacter pCharacter; // Reference to the player character.
    public AudioClip pickUpSfx, dropSfx;
    AudioSource audioSource;

    void Start()
    {
        pCharacter = FindObjectOfType<PlayerCharacter>(); // Find the player character in the scene.
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeClothes()
    {
        PlayerClothing pClothing = pCharacter.pClothing;

        if (pClothing.heldClothing == null)
        {
            pClothing.HoldClothes(clothes); // Pick up the clothes.
            audioSource.PlayOneShot(pickUpSfx);
        }
        else
        {
            pClothing.DropClothes(); // Drop the currently held clothes.
            audioSource.PlayOneShot(dropSfx);
        }
    }
}
