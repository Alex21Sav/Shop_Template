using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Product> _product;
    [SerializeField] private Purse _purse;
    [SerializeField] private ProductView _templateView;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        for (int i = 0; i < _product.Count; i++)
        {
            ProcessingArrays(_product[i]);
        }
        for (int i = 0; i < _product.Count; i++)
        {
            AddItem(_product[i]);
        }
    }
    private void AddItem(Product product)
    {
        var view = Instantiate(_templateView, _itemContainer.transform);
        view.SellButtonClickCoins += OnSellCoinsButtonClick;
        view.SellButtonClickStars += OnSellStarsButtonClick;
        view.Render(product);
    }
    public void OnSellCoinsButtonClick(Product product, ProductView view)
    {
        if (product.Coins <= _purse.Coins)
        {
            _purse.BuyProductCoins(product);
            product.Buy();
            view.Render(product);
        }
    }
    public void OnSellStarsButtonClick(Product product, ProductView view)
    {
        if (product.Stars <= _purse.Stars)
        {
            _purse.BuyProductStars(product);
            product.Buy();
            view.Render(product);
        }
    }
    private void ProcessingArrays(Product product)
    {
        _product = _product.OrderBy(product => product.Coins).ThenBy(product => product.Stars).ToList();
    }
}
