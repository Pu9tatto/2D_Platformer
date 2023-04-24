using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[CreateAssetMenu(menuName = "Defs/LocalDef", fileName = "LocalDef")]
public class LocalDef : ScriptableObject
{
    [SerializeField] private string _url;
    [SerializeField] private List<LocalItem> _localeItems;

    private UnityWebRequest _request;

    public Dictionary<string, string> GetData()
    {
        var dictionary = new Dictionary<string, string>();
        foreach(var item in _localeItems)
        {
            dictionary.Add(item.Key, item.Value);
        }
        return dictionary;
    }

    [ContextMenu("Update locale")]
    public void LoadLocales()
    {
        if (_request != null) return;

        _request = UnityWebRequest.Get(_url);
        _request.SendWebRequest().completed+= OnDataLoad;
    }

    private void OnDataLoad(AsyncOperation operation)
    {
        if (operation.isDone)
        {
            var rows = _request.downloadHandler.text.Split('\n');
            _localeItems.Clear();
            foreach(var row in rows)
            {
                AddLocalItem(row);
            }
        }
    }

    private void AddLocalItem(string row)
    {
        try
        {
            var parts = row.Split('\t');
            _localeItems.Add(new LocalItem { Key = parts[0], Value = parts[1] });
        }
        catch(Exception e)
        {
            Debug.LogError($"Can't parse row: {row}. \n {e}");
        }
    }

    [Serializable]
    private class LocalItem
    {
        public string Key;
        public string Value;
    }
}
