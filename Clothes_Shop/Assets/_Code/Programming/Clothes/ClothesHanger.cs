using UnityEngine;

public class ClothesHanger : MonoBehaviour
{
    public Clothing clothes; // Clothing item on the hanger
    
    private PlayerCharacter pCharacter; // Reference to the player character

    void Start()
    {
        pCharacter = FindObjectOfType<PlayerCharacter>(); // Find the player character in the scene
    }

    public void TakeClothes()
    {
        PlayerClothing pClothing = pCharacter.pClothing;

        if (pClothing.heldClothing == null)
        {
            pClothing.HoldClothes(clothes); // Player picks up the clothes
        }
        else
        {
            pClothing.DropClothes(); // Player drops the currently held clothes
        }
    }
}
