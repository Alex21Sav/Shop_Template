using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Purse : MonoBehaviour
{
    public float Coins;
    public float Stars;
    
    public event UnityAction<float, float> ResourcesChanget;    

    private void Start()
    {
        ResourcesChanget?.Invoke(Coins, Stars);          
    }     
    public void BuyProductCoins(Product product)
    {
        Coins -= product.Coins;
        PlayerPrefs.SetFloat("MoneySave", Coins);        
        ResourcesChanget?.Invoke(Coins, Stars);
        Debug.Log($"You bought {product.Lable}");
    }
    public void BuyProductStars(Product product)
    {
        Stars -= product.Stars;
        PlayerPrefs.SetFloat("BloodSave", Stars);        
        ResourcesChanget?.Invoke(Coins, Stars);
        Debug.Log($"You bought {product.Lable}");
    }
}
