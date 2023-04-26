using UnityEngine;
using UnityEngine.Events;

public class InteractableComponent : MonoBehaviour
{
    [SerializeField] private UnityEvent<GameObject> _actionGO;

    public void Interact(GameObject target)
    {
        _actionGO?.Invoke(target);
    }

}
