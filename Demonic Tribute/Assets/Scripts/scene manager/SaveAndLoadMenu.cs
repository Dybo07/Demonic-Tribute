
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndLoadMenu : MonoBehaviour
{
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
