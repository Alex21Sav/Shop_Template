using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourcesView : MonoBehaviour
{
    [SerializeField] private Purse _purse;
    [SerializeField] private TMP_Text _coin;
    [SerializeField] private TMP_Text _star;

    private void OnEnable()
    {
        _purse.ResourcesChanget += OnMoneyChanget;
    }
    private void OnMoneyChanget(float coin, float star)
    {
        _coin.text = coin.ToString();
        _star.text = star.ToString();
    }
    private void OnDisable()
    {
        _purse.ResourcesChanget -= OnMoneyChanget;
    }    
}
