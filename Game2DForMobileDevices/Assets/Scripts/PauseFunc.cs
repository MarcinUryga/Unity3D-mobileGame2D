using UnityEngine;
using System.Collections;

public class PauseFunc : MonoBehaviour
{
    public GameObject Pause;
    private HeroMove _hero;
    public GameObject PauseButton;
    public bool pauseFlag;
    private SceneMethod _scene;

    // Use this for initialization
    void Start()
    {
        Pause.SetActive(false);
        pauseFlag = false;
        _scene = GameObject.FindWithTag("MapSettings").GetComponent<SceneMethod>();
        _hero = GameObject.FindWithTag("Player").GetComponent<HeroMove>();
    }

    public void OnClick()
    {
        pauseFlag = !pauseFlag;
    }

    void OpenPauseMenu()
    {
        Pause.SetActive(true);
        Time.timeScale = 0;
    }

    void ClosePauseMenu()
    {
        Pause.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1;
    }
    
    public void ResumeButton()
    {
        pauseFlag = false;
    }

    public void RestartButton()
    {
        ClosePauseMenu();
        _scene.LoadLevel(_scene.sceneName);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        _hero.blockTheKeyboard = pauseFlag;

        if (!pauseFlag)
        ClosePauseMenu();
        if(pauseFlag)
        OpenPauseMenu();

    }
}
