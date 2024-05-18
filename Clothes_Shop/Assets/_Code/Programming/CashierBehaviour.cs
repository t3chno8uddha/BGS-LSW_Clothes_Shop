using UnityEngine;

public class CashierBehaviour : MonoBehaviour
{
    Conversation conversation;

    // Which events to bring up in case of successful and failed purchases. 
    public int soldEvent, insufficientEvent, maxEvent; 

    PlayerCharacter pCharacter; // Reference to the Player.
    
    void Start()
    {
        pCharacter = FindObjectOfType<PlayerCharacter>();
        conversation = GetComponent<Conversation>();
    }

    public void CashierConversation()
    {
        // Check the clothes that the player is holding.
        Clothing clothes = pCharacter.pClothing.heldClothing;

        if (clothes != null)
        {
            // If holding, buy.
            BuyClothes(clothes);
        }
        else
        {
            // If not holding anything, talk!
            conversation.Proceed();
        }
    }

    void BuyClothes(Clothing clothes)
    {
        // Check if the player has room left for items.
        if (pCharacter.inventory.Count < pCharacter.maxItems)
        {
            // Check if the player has enough money to buy.
            if (pCharacter.money >= clothes.price)
            {
                pCharacter.AddPurchase(clothes); // Add the purchased clothes to the player.
                pCharacter.UpdateMoney(pCharacter.money -= clothes.price); // Update the wallet.
                pCharacter.pClothing.DropClothes(); // Remove the clothes from the hand.
                conversation.ProceedWithDialogue(soldEvent); // Congratulate the purchase.
            }
            else
            {
                // Apologize for the inconvenience.
                conversation.ProceedWithDialogue(insufficientEvent);
            }
        }
        else
        {
            // No more room left!
            conversation.ProceedWithDialogue(maxEvent);
        }
    }
}