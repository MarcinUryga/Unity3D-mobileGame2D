using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HerosGunFunction : MonoBehaviour
{
    private Animator animator;
    public HeroMove _hero;
    public GameObject ammo;
    public GameObject ammoBox;

    public bool ifShot;

    public AudioSource _audioSource;
    public AudioClip _audioClip;
    public Text countAmmo;
    public int howMuchAmmo;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        _hero = GetComponent<HeroMove>();
    }
    void FixedUpdate()
    {
        countAmmo.text = (" x ") + howMuchAmmo.ToString();
    }

    public void Shot()
    {
        if (howMuchAmmo > 0)
        {
            if (_audioSource != null)
            {
                _audioSource.PlayOneShot(_audioClip);
            }

            if (_hero.transform.localScale.x == 1)
            {
                GameObject.Instantiate(ammo, new Vector3(_hero.transform.position.x + 2, _hero.transform.position.y, _hero.transform.position.z), _hero.transform.localRotation);
                ammo.transform.localScale = new Vector3(1f, 1f, 1f);

            }

            else if (_hero.transform.localScale.x == -1)
            {
                GameObject.Instantiate(ammo, new Vector3(_hero.transform.position.x - 2, _hero.transform.position.y, _hero.transform.position.z), _hero.transform.localRotation);
                ammo.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            ifShot = true;
            howMuchAmmo--;
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shot();
        }

        else ifShot = false;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "ammoBox(Clone)")
        {   
            howMuchAmmo += 15;
            Destroy(coll.gameObject);
        }
    }
    //451.027

    // Update is called once per frame
    void Update()
    {
        if (!_hero.blockTheKeyboard)
        {
            animator.SetBool("ifShot", ifShot);
            Attack();
        }
    }
}
