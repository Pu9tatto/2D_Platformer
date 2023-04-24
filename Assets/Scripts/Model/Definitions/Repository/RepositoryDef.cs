using UnityEngine;
using static UnityEditor.Progress;

public class RepositoryDef<TDefType> : ScriptableObject where TDefType : IHaveId
{
    [SerializeField] protected TDefType[] _collection;

    public TDefType Get(string id)
    {
        if (string.IsNullOrEmpty(id))
            return default;

        foreach (TDefType item in _collection)
        {
            if (item.Id == id)
                return item;
        }

        return default;
    }
}

