using System.Collections;
using UnityEngine;


public class HeroActions : MonoBehaviour
{
    [SerializeField] private CheckCircleOverlap _checkInteractableProps;
    [InventoryId] [SerializeField] private string _poisionId;
    
    private Inventory _inventory;
    private HealthComponent _healthComponent;

    private int _poisionCount => _inventory.Count(_poisionId);

    private void Start()
    {
        _inventory = GetComponent<Inventory>();
        _healthComponent = GetComponent<HealthComponent>();
    }



    public void Interact()
    {
        var interactableList = _checkInteractableProps.Check();

        foreach (var props in interactableList)
        {
            if (props.TryGetComponent(out InteractableComponent target))
            {
                target.Interact();
            }
        }
    }

    public void DrinkPoision()
    {
        if(_poisionCount > 0)
        {
            _healthComponent.ChangeHealth(1000);
            _inventory.RemoveInInventoryData(_poisionId, 1);
        }
    }
}
