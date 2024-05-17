using UnityEngine;

public class ClothesHanger : MonoBehaviour
{
    public bool isInReach = false;
    public Clothing clothes;
    
    GameObject playerHands;

    void Update()
    {
        if (isInReach)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                TakeClothes();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        isInReach = true;
    
        playerHands = collider.gameObject;
    }

    void OnTriggerExit2D (Collider2D collider)
    {
        isInReach = false;

        playerHands = null;
    }

    void TakeClothes()
    {
        PlayerClothing player = playerHands.transform.parent.GetComponentInParent<PlayerClothing>();
        
        if (player.heldClothing == null) player.HoldClothes(clothes);
        else player.DropClothes();
    }
}
