using UnityEngine;

public class CashierBehaviour : MonoBehaviour
{
    Conversation conversation;

    // Which events to bring up in case of successful and failed purchases. 
    public int soldEvent, insufficientEvent, maxEvent; 

    PlayerCharacter pCharacter; // Reference to the Player.

    public AudioClip soldClip, insufficientClip, maxClip;
    AudioSource audioSource;
    
    void Start()
    {
        pCharacter = FindObjectOfType<PlayerCharacter>();
        conversation = GetComponent<Conversation>();

        audioSource =  GetComponent<AudioSource>();
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
        pCharacter.pClothing.DropClothes(); // Remove the clothes from the hand.
        
        // Check if the player has room left for items.
        if (pCharacter.inventory.Count < pCharacter.maxItems)
        {
            // Check if the player has enough money to buy.
            if (pCharacter.money >= clothes.price)
            {
                audioSource.PlayOneShot(soldClip);

                pCharacter.AddPurchase(clothes); // Add the purchased clothes to the player.
                pCharacter.UpdateMoney(pCharacter.money -= clothes.price); // Update the wallet.
                conversation.ProceedWithDialogue(soldEvent); // Congratulate the purchase.
            }
            else
            {
                audioSource.PlayOneShot(insufficientClip);

                // Apologize for the inconvenience.
                conversation.ProceedWithDialogue(insufficientEvent);
            }
        }
        else
        {
            audioSource.PlayOneShot(maxClip);

            // No more room left!
            conversation.ProceedWithDialogue(maxEvent);
        }
    }
}