using UnityEngine;
using UnityEngine.UI;

public class InventoryItemWidget : MonoBehaviour, IItemRenderer<InventoryItemData>
{
    [SerializeField] private Image _icon;
    [SerializeField] private GameObject _selection;
    [SerializeField] private Text _value;

    private readonly CompositeDisposeable _trash = new CompositeDisposeable();

    private int _index;
    private GameSession _session;

    private void Start()
    {
        _session = FindObjectOfType<GameSession>();
        var index = _session.QuickInvetory.SelectedIndex;
        _trash.Retain(index.SubscribeAndInvoke(OnIndexChanged));
    }

    private void OnIndexChanged(int newValue, int _)
    {
        _selection.SetActive(_index == newValue);
    }

    public void SetData(InventoryItemData item, int index)
    {
        _index = index;
        var def = DefsFacade.I.Items.Get(item.Id);
        _icon.sprite = def.Icon;
        _value.text = def.HasTag(ItemTag.Stackable) ? item.Value.ToString() : string.Empty;
    }

    private void OnDestroy()
    {
        _trash.Dispose();
    }
}
