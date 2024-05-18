using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Inventory inventory;
    public PlayerCharacter pCharacter;
    public Image itemIcon, selectSprite;
    public Clothing clothing;

    public void EquipItem()
    {
        PlayerClothing pClothing = pCharacter.pClothing;

        pClothing.EquipClothes(clothing);
    }

    public void SellItem()
    {
        PlayerClothing pClothing = pCharacter.pClothing;

        pCharacter.inventory.Remove(clothing);

        if (pClothing.equipment.ContainsKey(clothing.type))
        {
            pClothing.equipment.Remove(clothing.type);

            SpriteRenderer clothingRenderer = null;
            if (clothing is Headwear) clothingRenderer = pClothing.headSprite;
            else if (clothing is Bodywear) clothingRenderer = pClothing.bodySprite;
            else if (clothing is Legwear) clothingRenderer = pClothing.legsSprite;

            clothingRenderer.sprite = null;
        }

        pCharacter.UpdateMoney(pCharacter.money += clothing.price);

        Close();
    }
    
    public void Close()
    {
        inventory.menuItems.Remove(this);
        Destroy(gameObject);
    }
}