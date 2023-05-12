using UnityEngine.SceneManagement;

public class LoseWindow : AnimatedWindow
{
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");

        var session = FindObjectOfType<GameSession>();
        Destroy(session);
    }
    public void Restart()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        GameSession.Session.LoadLastSave();
    }
}
