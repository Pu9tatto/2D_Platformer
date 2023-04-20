using UnityEngine;
using UnityEngine.Events;

public class TryAddItemInCollision : MonoBehaviour
{
    [SerializeField] private int _count;
    [InventoryId][SerializeField] private string _id;
    [SerializeField] private bool _isStackable;
    [SerializeField] private UnityEvent<GameObject> _action;

    private Collider2D _collider;
    private SpriteClipAnimation _animator;
    private void Awake()
    {
        _animator = GetComponent<SpriteClipAnimation>();
        _collider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        var item = DefsFacade.I.Items.Get(_id);
        _isStackable = item.HasTag(ItemTag.Stackable);

    }

    public void TryAddItem(GameObject target)
    {
        if (target.TryGetComponent(out Inventory inventory))
        {
            if (inventory.IsFull)
            {
                if(!_isStackable) return;
                if (GameSession.Session.Data.Inventory.GetItem(_id) == null) return;
            }  

            DoEventsAfterCollide();
            inventory.AddInInventoryData(_id, _count);
            _action?.Invoke(target.gameObject);
        }
    }

    private void DoEventsAfterCollide()
    {
        _collider.enabled = false;
        _animator.SetClip("Destroing");
    }
}
