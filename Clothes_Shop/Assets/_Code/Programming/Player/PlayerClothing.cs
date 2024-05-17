using System.Collections.Generic;
using UnityEngine;

public enum ClothingType
{ Headwear, Bodywear, Legwear }

public class PlayerClothing : MonoBehaviour
{
    public Clothing heldClothing;

    [Header("Equipment")]
    public Dictionary<ClothingType, Clothing> equipment = new Dictionary<ClothingType, Clothing>();

    public List<Clothing> starterClothes =new List<Clothing>();

    [Header("Sprite Renderers")]
    public SpriteRenderer handRenderer; // Sprite renderer for the held item.
    public SpriteRenderer headSprite, bodySprite, legsSprite; // Sprite renderers for head, body, and legs.
    
    PlayerCharacter pCharacter;

    void Start()
    {
        pCharacter = FindObjectOfType<PlayerCharacter>();

        foreach (Clothing item in pCharacter.inventory)
        {
            EquipClothes(item);
        }
    }

    public void EquipClothes(Clothing clothing)
    {
        // Display the equipped clothing sprite.
        SpriteRenderer clothingRenderer = null;
        
        if (clothing is Headwear)
        {
            clothingRenderer = headSprite;
        }
        else if (clothing is Bodywear)
        {
            clothingRenderer = bodySprite;
        }
        else if (clothing is Legwear)
        {
            clothingRenderer = legsSprite;
        }

        clothingRenderer.sprite = clothing.spriteSheet;

        // Check if there is already headwear equipped
        if (equipment.ContainsKey(clothing.type))
        {
            // Remove the previously equipped headwear
            equipment.Remove(clothing.type);
        }

        // Equip the new headwear
        equipment.Add(clothing.type, clothing);
    }

    public void HoldClothes(Clothing clothing)
    {
        print("Equipping");
        heldClothing = clothing;
        handRenderer.sprite = clothing.icon;
    }

    public void DropClothes()
    {
        print("Dropping");
        heldClothing = null;
        handRenderer.sprite = null;
    }
}