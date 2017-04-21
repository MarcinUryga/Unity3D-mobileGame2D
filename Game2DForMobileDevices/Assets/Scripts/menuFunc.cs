using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuFunc : MonoBehaviour
{
    public void StartFunc(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitFunc()
    {
        Application.Quit();
    }
}
