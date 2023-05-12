using UnityEngine;
using UnityEngine.UI;

public class GoodWidget : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Text _price;

    private Good _good;

    private void Awake()
    {
        _good = GetComponent<Good>();
    }

    private void Start()
    {
        _icon.sprite = _good.Icon;
        _price.text = _good.Price.ToString();
    }
}

