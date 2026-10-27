using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeLevel : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadByID(int levelID)
    { 
        SceneManager.LoadScene(levelID);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
