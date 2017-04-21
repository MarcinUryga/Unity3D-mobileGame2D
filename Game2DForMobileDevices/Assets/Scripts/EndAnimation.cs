using UnityEngine;
using System.Collections;

public class EndAnimation : MonoBehaviour
{
    private HeroMove _hero;
    private Animator endAnimation;
    private Camera mainCamera;
    private bool end;

    public GameObject[] buttons;

    // Use this for initialization
    void Start()
    {
        _hero = GameObject.FindWithTag("Player").GetComponent<HeroMove>();
        endAnimation = GetComponent<Animator>();
        mainCamera = Camera.main;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.name == "Hero")
        {
            StartCoroutine(zoom());

            _hero.gameObject.GetComponent<Renderer>().enabled = false;
            end = true;
        }
    }

    IEnumerator zoom()
    {
        do
        {
            mainCamera.GetComponent<Camera>().orthographicSize -= 0.1f;
            yield return new WaitForSeconds(0.001f);
        }while (mainCamera.GetComponent<Camera>().orthographicSize > 6) ;
        endAnimation.SetBool("SpitUp", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (end)
        {
            mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
            endAnimation.SetBool("EndAnimation", true);
            for (int i = 0; i < buttons.Length; i++)
                Destroy(buttons[i]);
            _hero.blockTheKeyboard = true;
        }
    }
}
