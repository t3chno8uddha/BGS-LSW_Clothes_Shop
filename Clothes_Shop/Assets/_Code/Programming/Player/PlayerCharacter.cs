using UnityEngine;

[RequireComponent(typeof(PlayerClothing), typeof(PlayerNavigation))]
public class PlayerCharacter : MonoBehaviour
{
    [HideInInspector] public PlayerClothing pClothing;
    [HideInInspector] public PlayerNavigation pNav;

    [HideInInspector] public int money;
    [HideInInspector] public Clothing clothesInventory;

    void Awake()
    {
        pClothing = GetComponent<PlayerClothing>();
        pNav = GetComponent<PlayerNavigation>();
    }
}