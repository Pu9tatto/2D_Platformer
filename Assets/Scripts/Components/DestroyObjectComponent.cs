using UnityEngine;

public class DestroyObjectComponent : MonoBehaviour
{
    [SerializeField] private GameObject _objectForDestroy;


    public void DestroyToObject()
    {
        Destroy(_objectForDestroy);
        if(TryGetComponent(out RestoreStateComponent _state))
            GameSession.Session.StoreState(_state.Id);
    }
}
