using UnityEngine;
using TMPro;

public class PriceSign : MonoBehaviour
{
    public Clothing clothing;
    
    void Start()
    {
        GetComponentInChildren<TextMeshPro>().text = "$" + clothing.price.ToString();
    }
}
