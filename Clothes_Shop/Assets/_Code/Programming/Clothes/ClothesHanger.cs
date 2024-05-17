using UnityEngine;

public class ClothesHanger : MonoBehaviour
{
    public Clothing clothes;
    
    PlayerCharacter pCharacter;
    void Start()
    {
        pCharacter = FindObjectOfType<PlayerCharacter>();
    }

    public void TakeClothes()
    {
        PlayerClothing pClothing = pCharacter.pClothing;

        if (pClothing.heldClothing == null) pClothing.HoldClothes(clothes);
        else pClothing.DropClothes();
    }
}