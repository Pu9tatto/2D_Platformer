using UnityEngine;

public static class WindowUtils
{
    public static void CreateWindow(string resourcesPath)
    {
        var window = Resources.Load<GameObject>(resourcesPath);
        var canvas = Object.FindObjectOfType<UIContainerWindows>();
        Object.Instantiate(window, canvas.transform);
    }
}
