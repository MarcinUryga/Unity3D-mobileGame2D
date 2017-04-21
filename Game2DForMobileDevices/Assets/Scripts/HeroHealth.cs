using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class HeroHealth : MonoBehaviour
{
    Dictionary<int, GameObject> associativeTableForEnergy = new Dictionary<int, GameObject>();
    private SceneMethod _scene;
    public int actualHealth;
    public int BlinkingTimes;
    public float BlinkingSpeed;
    public bool heroLostHealth;
    public HeroMove _drawHero;

    // Use this for initialization
    void Start()
    {
        CreateAssociativeTable();
        _scene = GameObject.FindWithTag("MapSettings").GetComponent<SceneMethod>();
        heroLostHealth = false;
        _drawHero = GameObject.FindWithTag("Player").GetComponent<HeroMove>();
    }

    void CreateAssociativeTable()
    {
        associativeTableForEnergy.Add(1, GameObject.Find("Energy1"));
        associativeTableForEnergy.Add(2, GameObject.Find("Energy2"));
        associativeTableForEnergy.Add(3, GameObject.Find("Energy3"));
        associativeTableForEnergy.Add(4, GameObject.Find("Energy4"));
        associativeTableForEnergy.Add(5, GameObject.Find("Energy5"));
    }

    void displayEnergy()
    {
        if(actualHealth < associativeTableForEnergy.Count)
            if(associativeTableForEnergy.ContainsKey(actualHealth))
                associativeTableForEnergy[actualHealth+1].gameObject.GetComponent<Image>().enabled = false;
    }

    IEnumerator Blinking()
    {
        heroLostHealth = true;
        for (int i = 0; i <= BlinkingTimes; i++)
        {
            if (i == BlinkingTimes)
                heroLostHealth = false;
            _drawHero.gameObject.GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(BlinkingSpeed / 2);
            _drawHero.gameObject.GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(BlinkingSpeed / 2);
        }
    }

    void contactWithEnemy()
    {
        StartCoroutine(Blinking());
    }

    public void LostHealth()
    {
        if (actualHealth == 0)
            _scene.LoadLevel(_scene.sceneName);

        if (!heroLostHealth)
        {
            contactWithEnemy();
            actualHealth--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        displayEnergy();
    }
}
