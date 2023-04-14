using Newtonsoft.Json.Bson;
using UnityEngine;

public static class GameObjectExtansions
{
    public static bool IsInLayer(this GameObject gameObject, LayerMask layer) =>
        layer == (layer | 1 << gameObject.layer);

    public static bool IsInLayer(this GameObject gameObject, LayerMask[] layers)
    {
        bool result = true;
        foreach (var layer in layers)
        {
            result &= layer == (layer | 1 << gameObject.layer);
        }
        return result;
    }

    public static TInterfaceType GetInterface<TInterfaceType>(this GameObject go)
    {
        var components = go.GetComponents<Component>();
        foreach(var component in components)
        {
            if(component is  TInterfaceType type)
            {
                return type;
            }
        }

        return default;
    }

}
