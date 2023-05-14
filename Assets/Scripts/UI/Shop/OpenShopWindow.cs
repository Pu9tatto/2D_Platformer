using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenShopWindow : MonoBehaviour
{
    [SerializeField] private List<Good> goods;
    [SerializeField] private UnityEvent _closeAction;

    private ShopWidget _shop;
    private bool _isOpened = false;

    public void OpenShop()
    {
        _isOpened = true;
        Time.timeScale = 0;
        var window = Resources.Load<ShopWidget>("UI/ShopWindow");
        var canvas = FindObjectOfType<UIContainerWindows>();
        _shop = Instantiate(window, canvas.transform);

        _shop.InitGoods(goods);
        _shop.CloseAction += OnCloseAction;
    }

    private void OnCloseAction()
    {
        Time.timeScale = 1;
        _closeAction?.Invoke();
    }

    private void OnDisable()
    {
        if(_isOpened)
        {
            _isOpened = false;
            _shop.CloseAction -= OnCloseAction;
        }
    }
}
