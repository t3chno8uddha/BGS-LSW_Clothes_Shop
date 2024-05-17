using UnityEngine;

public class Inventory : MonoBehaviour
{
    PlayerCharacter pCharacter;
    public InventoryItem item;

    void Start()
    {
        pCharacter = FindObjectOfType<PlayerCharacter>();
    }

    public void AddItem(Clothing newClothing)
    {
        InventoryItem newItem = Instantiate(item.gameObject, transform).GetComponent<InventoryItem>();

        newItem.inventory = this;
        newItem.pCharacter = pCharacter;

        newItem.clothing = newClothing;

        newItem.itemIcon.sprite = newClothing.icon;
        newItem.itemIcon.enabled = true;
    }
}