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
        SpriteRenderer clothingRenderer = null;
        if (clothing is Headwear) clothingRenderer = headSprite;
        else if (clothing is Bodywear) clothingRenderer = bodySprite;
        else if (clothing is Legwear) clothingRenderer = legsSprite;


        if (equipment.ContainsValue(clothing))
        {
            // Remove the previously equipped headwear
            equipment.Remove(clothing.type);

            clothingRenderer.sprite = null;
        }

        else
        {
            // Check if there is already headwear equipped
            if (equipment.ContainsKey(clothing.type))
            {
                // Remove the previously equipped headwear
                equipment.Remove(clothing.type);
            }

            // Display the equipped clothing sprite.
            clothingRenderer.sprite = clothing.spriteSheet;
            // Equip the new headwear
            equipment.Add(clothing.type, clothing);
        }
    }

    public void HoldClothes(Clothing clothing)
    {
        heldClothing = clothing;
        handRenderer.sprite = clothing.icon;
    }

    public void DropClothes()
    {
        heldClothing = null;
        handRenderer.sprite = null;
    }
}