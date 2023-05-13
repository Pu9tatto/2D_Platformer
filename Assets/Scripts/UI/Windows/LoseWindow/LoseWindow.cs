using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseWindow : AnimatedWindow
{
    [SerializeField] private Button _restartButton;

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");

        var session = FindObjectOfType<GameSession>();
        Destroy(session.gameObject);
    }
    public void Restart()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        GameSession.Session.LoadLastSave();
        GameSession.Session.Data.Inventory.Remove("Hat",1);
        GameSession.Session.Save();
    }

    public void DeactivateRestart() =>  _restartButton.interactable = false;
}
