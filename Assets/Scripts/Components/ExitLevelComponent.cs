using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevelComponent : MonoBehaviour
{
    [SerializeField] private string _levelName;

    public void Exit()
    {
        SceneManager.LoadScene(_levelName);
    }
}
