using UnityEngine;
using System.Collections;

public class BossAmmo : MonoBehaviour
{
    public Rigidbody2D ammo;
    public float Speed;
    public float value;
    private HeroHealth _hero;


    // Use this for initialization
    void Start()
    {
 
        ammo = GetComponent<Rigidbody2D>();
        ammo.gravityScale = Random.Range(-10, 10);
        _hero = GameObject.FindWithTag("HUDHealth").GetComponent<HeroHealth>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Hero")
        {
            _hero.LostHealth();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ammo.velocity = new Vector2(-Speed, ammo.velocity.y);
    }
}
