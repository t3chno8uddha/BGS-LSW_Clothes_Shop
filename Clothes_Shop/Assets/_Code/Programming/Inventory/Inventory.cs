using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private PlayerCharacter pCharacter; // Reference to the player character
    public InventoryItem item; // Inventory item prefab
    public GameObject menuObject; // UI object for the inventory menu

    public List<InventoryItem> menuItems = new List<InventoryItem>(); // List of items in the inventory menu

    void Start()
    {
        pCharacter = FindObjectOfType<PlayerCharacter>(); // Find the player character in the scene
    }

    // Adds a new item to the inventory menu
    public void AddItem(Clothing newClothing)
    {
        // Instantiate a new inventory item UI element
        InventoryItem newItem = Instantiate(item, menuObject.transform).GetComponent<InventoryItem>();
        
        // Add the new item to the list of menu items
        menuItems.Add(newItem);
    
        // Set references and properties for the new inventory item
        newItem.inventory = this;
        newItem.pCharacter = pCharacter;
        newItem.clothing = newClothing;
        newItem.itemIcon.sprite = newClothing.icon;
        newItem.itemIcon.enabled = true;
    }

    // Toggles the visibility of the inventory menu
    public void ToggleMenu()
    {
        if (menuObject.activeInHierarchy)
        {
            pCharacter.pNav.isConversing = false;

            // Prepare a list to clear the menu items
            List<GameObject> clearQueue = new List<GameObject>();
            
            // Add all menu items to the clear queue and clear the menuItems list
            foreach (InventoryItem menuItem in menuItems) 
            {
                clearQueue.Add(menuItem.gameObject);
            }
            menuItems.Clear();

            // Destroy all items in the clear queue
            foreach (GameObject queueObject in clearQueue) 
            {
                Destroy(queueObject);
            }
            // Hide the inventory menu
            menuObject.SetActive(false);
        }
        else
        {
            pCharacter.pNav.isConversing = true;

            // Show the inventory menu
            menuObject.SetActive(true);

            // Add all items from the player's inventory to the menu
            foreach (Clothing clothing in pCharacter.inventory)
            {
                AddItem(clothing);
            }
        }
    }
}
