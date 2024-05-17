using UnityEngine;

public class CashierBehaviour : MonoBehaviour
{
    Conversation conversation;

    public int soldEvent, insufficientEvent;

    PlayerCharacter pCharacter;
    void Start()
    {
        pCharacter = FindObjectOfType<PlayerCharacter>();
        conversation = GetComponent<Conversation>();
    }

    public void CashierConversation()
    {
        Clothing clothes = pCharacter.pClothing.heldClothing;

        if (clothes != null)
        {
            BuyClothes(clothes);
        }
        else
        {
            conversation.Proceed();
        }
    }

    void BuyClothes(Clothing clothes)
    {
        if (pCharacter.money >= clothes.price)
        {
            pCharacter.clothesInventory.Add(clothes);

            pCharacter.UpdateMoney(pCharacter.money -= clothes.price);

            pCharacter.pClothing.DropClothes();

            conversation.ProceedWithDialogue(soldEvent);
        }
        else
        {
            conversation.ProceedWithDialogue(insufficientEvent);
        }
    }
}