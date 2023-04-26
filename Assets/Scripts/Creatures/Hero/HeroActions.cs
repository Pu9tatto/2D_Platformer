using UnityEngine;

public class HeroActions : MonoBehaviour
{
    [SerializeField] private CheckCircleOverlap _checkInteractableProps;
    [SerializeField] private PlaysSoundsComponent _sounds;

    private string _itemId; 
    private Inventory _inventory;
    private GameSession _session;

    private void Start()
    {
        _session = GameSession.Session;
        _inventory = GetComponent<Inventory>();
    }

    public void Interact()
    {
        var interactableList = _checkInteractableProps.Check();

        foreach (var props in interactableList)
        {
            if (props.TryGetComponent(out InteractableComponent target))
            {
                target.Interact(gameObject);
            }
        }
    }

    public void UseItem()
    {
        if (IsSelectedItem(ItemTag.Potion))
        {
            _itemId = _session.QuickInvetory.SelectedItem.Id;
            UsePotion();
        }
    }

    private void UsePotion()
    {
        var potion = DefsFacade.I.Potion.Get(_itemId);

        _session.Data.Hp.Value += (int) potion.Value;
        _sounds.Play("Heal");

        _inventory.RemoveInInventoryData(potion.Id, 1);
    }

    public void OnNextItem()
    {
        _session.QuickInvetory.SetNextItem();
    }

    public void OnPause()
    {
        if(Time.timeScale > 0)
        {
            WindowUtils.CreateWindow("UI/InGameMenuWindow");
        }
    }

    private bool IsSelectedItem(ItemTag tag)
    {
        return _session.QuickInvetory.SelectedDef.HasTag(tag);
    }
}
