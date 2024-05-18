using System.Collections.Generic;
using UnityEngine;

public enum ClothingType
{ Headwear, Bodywear, Legwear }

public class PlayerClothing : MonoBehaviour
{
    public Clothing heldClothing; // Reference for if a player is holding clothes.

    // A dictionary to handle player equipment. We use a dictionary so that there are different types of equipments.
    public Dictionary<ClothingType, Clothing> equipment = new Dictionary<ClothingType, Clothing>();

    [Header("Sprite Renderers")]
    public SpriteRenderer handRenderer; // Sprite renderer for the held item.
    public SpriteRenderer headSprite, bodySprite, legsSprite; // Sprite renderers for head, body, and legs.
    
    PlayerCharacter pCharacter; // Player reference.

    void Start()
    {
        pCharacter = FindObjectOfType<PlayerCharacter>();

        // Equip our existing clothes upon loading in.
        foreach (Clothing item in pCharacter.inventory)
        {
            EquipClothes(item);
        }
    }

    public void EquipClothes(Clothing clothing)
    {
        // Find the correct sprite renderer.
        SpriteRenderer clothingRenderer = null;
        if (clothing is Headwear) clothingRenderer = headSprite;
        else if (clothing is Bodywear) clothingRenderer = bodySprite;
        else if (clothing is Legwear) clothingRenderer = legsSprite;


        if (equipment.ContainsValue(clothing))
        {
            // Remove the previously equipped clothing.
            equipment.Remove(clothing.type);

            clothingRenderer.sprite = null;
        }

        else
        {
            // Check if there is already clothing equipped.
            if (equipment.ContainsKey(clothing.type))
            {
                // Remove the previously equipped clothing.
                equipment.Remove(clothing.type);
            }

            // Display the equipped clothing sprite.
            clothingRenderer.sprite = clothing.spriteSheet;
            // Equip the new clothing.
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