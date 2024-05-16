using UnityEngine;

public class PlayerClothing : MonoBehaviour
{
    public Headwear headwear;
    public Bodywear bodywear;
    public Legwear legwear;

    public SpriteRenderer headSprite, bodySprite, legsSprite;

    void Start()
    {
        EquipClothing(headwear, bodywear, legwear);
    }

    void EquipClothing(Headwear newHead = null, Bodywear newBody = null, Legwear newLegs = null)
    {
        // Check if we're passing new headwear.
        if (newHead != null) { EquipItem (newHead, headSprite); }
        // Check if we're passing new bodywear.
        if (newBody != null) { EquipItem (newBody, bodySprite); }
        // Check if we're passing new legwear.
        if (newLegs != null) { EquipItem (newLegs, legsSprite); }
    }

    void EquipItem(Clothing clothing, SpriteRenderer renderer)
    {
        print ("Equipped");
        // Set the actual spritesheet to that piece of clothing
        renderer.sprite = clothing.spriteSheet;
    }
}