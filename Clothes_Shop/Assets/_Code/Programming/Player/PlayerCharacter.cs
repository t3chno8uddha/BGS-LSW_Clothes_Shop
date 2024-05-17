using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(PlayerClothing), typeof(PlayerNavigation))]
public class PlayerCharacter : MonoBehaviour
{
    [HideInInspector] public PlayerClothing pClothing;
    [HideInInspector] public PlayerNavigation pNav;

    public int money = 200;
    public TextMeshProUGUI moneyBox;
    
    public List<Clothing> clothesInventory = new List<Clothing>();



    void Awake()
    {
        pClothing = GetComponent<PlayerClothing>();
        pNav = GetComponent<PlayerNavigation>();
    }

    void Start()
    {
        UpdateMoney(money);
    }

    public void UpdateMoney(int newMoney)
    {
        money = newMoney;
        moneyBox.text = money.ToString();
    }
}