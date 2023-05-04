using UnityEngine;

public class SpawnComponent : MonoBehaviour
{
    [SerializeField] protected GameObject[] _prefabs;

    public virtual void Spawn()
    {
        foreach (var prefab in _prefabs)
        {
            var tamplate = Instantiate(prefab, transform.position, Quaternion.identity);
            tamplate.transform.localScale = transform.lossyScale;
        }
    }

    public virtual void SetPrefab(GameObject prefab)
    {
        _prefabs[0] = prefab;
    }
}
