using UnityEngine;
using System.Collections;

public class pseudoMenu : MonoBehaviour
{
    public GameObject[] objects;

    public void StartButton()
    {
        for (int i = 0; i < objects.Length; i++)
            Destroy(objects[i]);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
