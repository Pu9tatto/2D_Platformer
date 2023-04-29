using UnityEngine;

public class DestroyObjectComponent : MonoBehaviour
{
    [SerializeField] private GameObject _objectForDestroy;
    [SerializeField] private float _delay = 0;

    public void DestroyToObject()
    {
        Destroy(_objectForDestroy, _delay);
        if(TryGetComponent(out RestoreStateComponent _state))
            GameSession.Session.StoreState(_state.Id);
    }
}
