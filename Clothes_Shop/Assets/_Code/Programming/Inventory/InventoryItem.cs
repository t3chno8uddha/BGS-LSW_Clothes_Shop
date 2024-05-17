using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public PlayerCharacter pCharacter;
    public Inventory inventory;
    public Image itemIcon, selectSprite;
    public Clothing clothing;

    public void EquipItem()
    {
        PlayerClothing pClothing = pCharacter.pClothing;

        // Check if there is already headwear equipped
        if (pClothing.equipment.ContainsKey(clothing.type))
        {
            // Remove the previously equipped headwear
            pClothing.equipment.Remove(clothing.type);
        }

        // Equip the new headwear
        pClothing.equipment.Add(clothing.type, clothing);
    }
}