using UnityEngine;

public class CashierBehaviour : MonoBehaviour
{
    Conversation conversation;

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

    }
}