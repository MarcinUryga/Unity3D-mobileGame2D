using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour
{
    public Rigidbody2D ammo;
    public GameObject _hero;
    public float Speed;
    public float value;
    private ScoreManager _score;

    // Use this for initialization
    void Start()
    {
        ammo = GetComponent<Rigidbody2D>();
        _hero = GameObject.FindWithTag("Player");
        _score = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "Enemy(Clone)" || coll.name == "Boss(Clone)")
        {
            _score.addPoint();
            _score.TrySetHighScore();
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_hero.transform.localScale.x == 1 && (Mathf.Abs(ammo.position.x - _hero.transform.position.x) <= value))
            ammo.AddForce(transform.right * Speed * 1 / Time.deltaTime);

        else if (_hero.transform.localScale.x == -1 && (Mathf.Abs(ammo.position.x - _hero.transform.position.x) <= value))
            ammo.AddForce(-transform.right * Speed * 1 / Time.deltaTime);
    }
}
