using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProductView : MonoBehaviour
{
    [Header("Coins")]
    [SerializeField] private Button _sellButtonCoins;
    [SerializeField] private TMP_Text _coins;
    [Header("Stars")]
    [SerializeField] private Button _sellButtonStars;
    [SerializeField] private TMP_Text _stars;
    [Space]
    [SerializeField] private TMP_Text _lable;
    [Space]
    [SerializeField] private Image _icon;
    [Space(10)]
    [Header("Timer activations")]
    [SerializeField] private Image _timerBar;
    [SerializeField] private TMP_Text _timeAction;    
    [SerializeField] private GameObject _timer;

    private float _activationsTime;    
    private bool _isButton = false;
    private float _timeLeft;

    private Product _product;

    public event UnityAction<Product, ProductView> SellButtonClickCoins;
    public event UnityAction<Product, ProductView> SellButtonClickStars;
    
    private void OnEnable()
    {
        _sellButtonCoins.onClick.AddListener(OnButtonClickCoin);
        _sellButtonStars.onClick.AddListener(OnButtonClickStar);        
    }
    private void Start()
    {
        _activationsTime = _product.ActivationsTime;
        //LoadGame();
        _timeLeft = _activationsTime;
    }
    private void Update()
    {
        ProductActive();
    }
    private void OnButtonClickCoin()
    {
        _isButton = true;
        _timer.SetActive(true);
        SellButtonClickCoins?.Invoke(_product, this);        
        _sellButtonCoins.interactable = false;
        _sellButtonStars.interactable = false;
    }
    private void OnButtonClickStar()
    {
        _isButton = true;
        _timer.SetActive(true);
        SellButtonClickStars?.Invoke(_product, this);        
        _sellButtonCoins.interactable = false;
        _sellButtonStars.interactable = false;
    }
    private void ProductActive()
    {
        if (_timeLeft > 0 && _isButton)
        {
            _timeAction.gameObject.SetActive(true);
            _timeLeft -= Time.deltaTime;
            _timerBar.fillAmount = _timeLeft / _activationsTime;
            _timeAction.text = "00:00:00";
            _timeAction.text = _timeLeft.ToString("00:00:00");

            //SaveGame();
            // Purchase bonus activation.
            if (_timeLeft <= 0)
            {
                _isButton = false;
                _timer.SetActive(false);
                _timerBar.fillAmount = _activationsTime;
                _timeLeft = _activationsTime;
                _sellButtonCoins.interactable = true;
                _sellButtonStars.interactable = true;
                _timeAction.gameObject.SetActive(false);
                               
                //Сompletion of the bonus from the purchase.
            }
        }
    }
    public void Render(Product product)
    {
        _product = product;
        _coins.text = product.Coins.ToString();
        _stars.text = product.Stars.ToString();
        _lable.text = product.Lable;
        _icon.sprite = product.Icon;
    }    
    //public void SaveGame()
    //{        
    //    PlayerPrefs.SetFloat("TimeActionSave", _timeLeft);        
    //    PlayerPrefs.Save();
    //    //Debug.Log("Game data saved!");
    //}
    //public void LoadGame()
    //{
    //    if (PlayerPrefs.HasKey("TimeActionSave"))
    //    {
    //        _timeLeft = PlayerPrefs.GetFloat("TimeActionSave");            
    //        _isButton = true;            
    //        Debug.Log("Game data loaded!");
    //    }
    //    else
    //    {
    //        _timeLeft = _activationsTime;
    //        Debug.LogError("There is no save data!");
    //    }            
    //}
    /*
     * Не выполнил часть задания кусаемое сохранения статуса покупки(не смог/не успел).
     * Столкнулся с проблемой - сохранённое состояния касается одного конкретного экземпляра,
     * при загрузки, все экземпляры получают одно и тоже значение. 
    */
    private void OnDisable()
    {
        _sellButtonCoins.onClick.RemoveListener(OnButtonClickCoin);
        _sellButtonStars.onClick.RemoveListener(OnButtonClickStar);
    }
}
