using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenShopWindow : MonoBehaviour
{
    [SerializeField] private List<Good> goods;
    [SerializeField] private UnityEvent _closeAction;

    private float timeScale;
    private ShopWidget _shop;

    public void OpenShop()
    {
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
        _shop.CloseAction -= OnCloseAction;
    }
}
