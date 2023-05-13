using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevelComponent : MonoBehaviour
{
    public void Reload()
    {
        var inventory = GameSession.Session.Data.Inventory;
        var hatValue = inventory.GetCount("Hat");
        if(hatValue <= 1)
        {
            SceneManager.LoadScene("MainMenu");

            var session = FindObjectOfType<GameSession>();
            Destroy(session.gameObject);
        }
        else
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            GameSession.Session.LoadLastSave();
        }
        GameSession.Session.Data.Inventory.Remove("Hat", 1);
        GameSession.Session.Save();
    }
}
