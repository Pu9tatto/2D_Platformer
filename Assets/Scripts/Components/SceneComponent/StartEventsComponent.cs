using UnityEngine;
using UnityEngine.Events;

public class StartEventsComponent : MonoBehaviour
{
    [SerializeField] private UnityEvent[] _actions;

    private void Start()
    {
        foreach (var action in _actions)
        {
            action?.Invoke();
        }
    }
}

