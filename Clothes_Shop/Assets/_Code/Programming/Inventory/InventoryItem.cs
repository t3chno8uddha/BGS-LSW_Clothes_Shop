using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Inventory inventory; // Reference to the inventory this item belongs to
    public PlayerCharacter pCharacter; // Reference to the player character
    public Image itemIcon, selectSprite; // UI elements for the item icon and selection sprite
    public Clothing clothing; // The clothing item associated with this inventory item


    // Method to equip this item to the player character
    public void EquipItem()
    {
        inventory.audioSource.PlayOneShot(inventory.equipClip);

        PlayerClothing pClothing = pCharacter.pClothing;
        pClothing.EquipClothes(clothing); // Equip the clothing item
    }

    // Method to sell this item
    public void SellItem()
    {
        inventory.audioSource.PlayOneShot(inventory.sellClip);

        PlayerClothing pClothing = pCharacter.pClothing;

        // Remove the clothing item from the player's inventory
        pCharacter.inventory.Remove(clothing);

        // Check if the clothing is currently equipped and remove it
        if (pClothing.equipment.ContainsKey(clothing.type))
        {
            Clothing previousClothing;
            if (pClothing.equipment.TryGetValue(clothing.type, out previousClothing))
            {
                if (previousClothing == clothing)
                {
                    pClothing.equipment.Remove(clothing.type);

                    SpriteRenderer clothingRenderer = null;

                    // Determine which sprite renderer to clear based on the clothing type
                    if (clothing is Headwear) clothingRenderer = pClothing.headSprite;
                    else if (clothing is Bodywear) clothingRenderer = pClothing.bodySprite;
                    else if (clothing is Legwear) clothingRenderer = pClothing.legsSprite;

                    if (clothingRenderer != null)
                    {
                        clothingRenderer.sprite = null;
                    }
                }
            }
        }

        // Sell the clothes.
        pCharacter.UpdateMoney(pCharacter.money + clothing.price);

        // Remove this inventory item from the menu and destroy its game object
        Close();
    }
    
    public void Close()
    {
        inventory.menuItems.Remove(this); // Remove from the inventory menu
        Destroy(gameObject); // Destroy the game object
    }
}
