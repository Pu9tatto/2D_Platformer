using UnityEngine;

public class OpenWindow : MonoBehaviour
{
    [SerializeField] private string _path;
    
    public void Open()
    {
        var window = Resources.Load<PlayerStatsWindow>(_path);
        var canvas = FindObjectOfType<UIContainerWindows>();
        Instantiate(window, canvas.transform);
    }
}
