using UnityEngine;

public class PlayerClothing : MonoBehaviour
{
    public Clothing heldClothing;

    [Header("Equipment")]
    public Headwear headwear; // The headwear item to equip.
    public Bodywear bodywear; // The bodywear item to equip.
    public Legwear legwear; // The legwear item to equip.

    [Header("Sprite Renderers")]
    public SpriteRenderer handRenderer; // Sprite renderer for the held item.
    public SpriteRenderer headSprite, bodySprite, legsSprite; // Sprite renderers for head, body, and legs.

    void Start()
    {
        EquipClothing (headwear, bodywear, legwear);
    }
    
    void EquipClothing(Headwear newHead = null, Bodywear newBody = null, Legwear newLegs = null)
    {
        // Check and equip new headwear if provided.
        if (newHead != null) { EquipItem(newHead, headSprite); }
        // Check and equip new bodywear if provided.
        if (newBody != null) { EquipItem(newBody, bodySprite); }
        // Check and equip new legwear if provided.
        if (newLegs != null) { EquipItem(newLegs, legsSprite); }
    }

    void EquipItem(Clothing clothing, SpriteRenderer renderer)
    {
        // Display the equipped clothing sprite.
        renderer.sprite = clothing.spriteSheet;
    }

    public void HoldClothes(Clothing clothing)
    {
        print("Equipping");
        heldClothing = clothing;
        handRenderer.sprite = clothing.icon;
    }

    public void DropClothes()
    {
        print("Dropping");
        heldClothing = null;
        handRenderer.sprite = null;
    }
}