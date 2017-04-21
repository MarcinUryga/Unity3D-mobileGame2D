using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneMethod : MonoBehaviour
{
    public string sceneName;

    public void LoadLevel(string sceneName)
    {
            SceneManager.LoadScene(sceneName);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "Hero")
            LoadLevel(sceneName);

        else Destroy(coll.gameObject);
    }
}
