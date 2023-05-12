using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartSceneShop : MonoBehaviour
{
    [SerializeField] private List<Good> goods;
    [SerializeField] private bool _activatedOnStart = false;
    [SerializeField] private UnityEvent _closeAction;

    private float timeScale;
    private ShopWidget _shop;

    private void Start()
    {
        timeScale = Time.timeScale;
        if (_activatedOnStart)
            OpenShop();
    }

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
        Time.timeScale = timeScale;
        _closeAction?.Invoke();
    }

    private void OnDisable()
    {
        _shop.CloseAction -= OnCloseAction;
    }
}
