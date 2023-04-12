using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevelComponent : MonoBehaviour
{
    [SerializeField] private string _levelName;

    public void Exit()
    {
        GameSession.Session.Save();
        SceneManager.LoadScene(_levelName);
    }
}
