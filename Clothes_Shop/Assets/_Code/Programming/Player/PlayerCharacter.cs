using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(PlayerClothing), typeof(PlayerNavigation))]
public class PlayerCharacter : MonoBehaviour
{
    // References to the other player classes.
    [HideInInspector] public PlayerClothing pClothing; 
    [HideInInspector] public PlayerNavigation pNav;

    public int money = 200; // Player's total money.
    public TextMeshProUGUI moneyBox; // The text box that displays money.
    
    public int maxItems = 20;
    public List<Clothing> inventory = new List<Clothing>(); // The player's clothing inventory.
    public Inventory inventoryMenu; // The GUI responsible for inventory display.

    public AudioClip moneyClip;
    AudioSource audioSource;

    void Awake()
    {
        // Get the default references.
        pClothing = GetComponent<PlayerClothing>();
        pNav = GetComponent<PlayerNavigation>();
    }

    void Start()
    {
        // Update the money once the game starts.
        UpdateMoney(money);
        audioSource = GetComponent<AudioSource>();
    }

    public void AddPurchase(Clothing clothing)
    {
        inventory.Add(clothing); // Add the clothes to the inventory.
    }

    public void AddMoney(int newMoney)
    {
        audioSource.PlayOneShot(moneyClip);
        UpdateMoney(money+newMoney);
    }

    public void UpdateMoney(int newMoney)
    {
        // Set the new money amount and send it to the GUI.

        money = newMoney;
        moneyBox.text = money.ToString();
    }
}