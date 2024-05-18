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

        pClothing.EquipClothes(clothing);
    }
}