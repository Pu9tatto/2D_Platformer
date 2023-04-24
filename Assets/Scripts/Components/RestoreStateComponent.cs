using UnityEngine;

public class RestoreStateComponent : MonoBehaviour
{
    [SerializeField] private string _id;
    private GameSession _session;

    public string Id => _id;

    private void Start()
    {
        _session = GameSession.Session;

        var isDestroyed = _session.RestoreSrate(_id);
        if(isDestroyed)
            Destroy(gameObject);
    }
}
