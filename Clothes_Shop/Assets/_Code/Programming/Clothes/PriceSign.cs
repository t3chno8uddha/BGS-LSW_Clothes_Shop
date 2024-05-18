using UnityEngine;
using TMPro;

public class PriceSign : MonoBehaviour
{
    public Clothing clothing;
    
    void Start()
    {
        // Set the child text to the item's price.
        GetComponentInChildren<TextMeshPro>().text = "$" + clothing.price.ToString();
    }
}
