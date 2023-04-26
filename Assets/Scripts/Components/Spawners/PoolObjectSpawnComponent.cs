using UnityEngine;

public class PoolObjectSpawnComponent : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _spawnPoint;

    private void Start()
    {
        Initialize(_template);
    }

    public void Spawn()
    {
        if(TryGetObject(out GameObject tamplate))
        {
            tamplate.transform.position = _spawnPoint.position;
            tamplate.transform.localScale = _spawnPoint.lossyScale;
            tamplate.SetActive(true);
        }
    }
}
