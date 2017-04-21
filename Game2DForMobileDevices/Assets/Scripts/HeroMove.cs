using UnityEngine;
using System.Collections;

public class HeroMove : MonoBehaviour 
{
    public bool left = false, right = false;

    private bool touchHindranceUp;
    private bool touchHindranceDown;
    public bool touchGround;
    public bool move;

    public float Speed;
    public float radiusOfGroundSensor;
    public float radiusOfHindranceSensor;

    public Transform groundSensor;
    public Transform hindranceSensorUp;
    public Transform hindranceSensorDown;

    public LayerMask layer;
    private Rigidbody2D hero;
    private Animator animator;

    private HeroHealth _hero;
    private bool ifOnPlatform = false;
    public bool blockTheKeyboard;


    // Use this for initialization
    void Start()
    {
        blockTheKeyboard = false;
        hero = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _hero = GameObject.FindWithTag("HUDHealth").GetComponent<HeroHealth>();
    }

    void BounceFunction()
    {
        touchHindranceUp = Physics2D.OverlapCircle(hindranceSensorUp.position, radiusOfHindranceSensor, layer);
        touchHindranceDown = Physics2D.OverlapCircle(hindranceSensorDown.position, radiusOfHindranceSensor, layer);

        if (touchHindranceUp || touchHindranceDown)
        {
            float bounceHero = 0.2f;
            if (hero.transform.localScale.x == 1)
                bounceHero *= -1;
            hero.transform.localPosition = new Vector2(hero.transform.position.x + bounceHero, hero.transform.position.y);
        }
    }

    public void MoveLeft()
    {
        left = true;
    }

    public void MoveRight()
    {
        right = true;
    }

    public void DontMoveLeft()
    {
        left = false;
    }

    public void DontMoveRight()
    {
        right = false;
    }

    public void Jump()
    {
        if (hero.velocity.y == 0f)
            hero.AddForce(new Vector2(0f, 1000f));
    }

    void CheckMovement()
    {

        if (!blockTheKeyboard)
        {
            if (left || Input.GetKey(KeyCode.A))
            {
                move = true;

                hero.velocity = new Vector2(-Speed, hero.velocity.y);
                hero.transform.localScale = new Vector3(-1, 1, 1);
            }

            if (right || Input.GetKey(KeyCode.D))
            {
                move = true;

                hero.velocity = new Vector2(Speed, hero.velocity.y);
                hero.transform.localScale = new Vector3(1, 1, 1);
            }

            else if (!left && !right && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
                move = false;

            if (Input.GetKeyDown(KeyCode.W))
                Jump();
        }

    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Enemy(Clone)" || coll.gameObject.name == "Boss(Clone)")
        {
            _hero.LostHealth();
        }

        if (coll.transform.tag == "MovingPlatform")
        {
            ifOnPlatform = true;
            transform.parent = coll.transform;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.transform.tag == "MovingPlatform")
        {
            ifOnPlatform = false;
            transform.parent = null;
        }
    }

    void FixedUpdate()
    {
        BounceFunction();
        //beforePosition = hero.transform.position.x;
        if (ifOnPlatform)
        {
            touchGround = true;
            //beforePosition = transform.parent.position.x;
        }
        else
            touchGround = Physics2D.OverlapCircle(groundSensor.position, radiusOfGroundSensor, layer);
    }

    // Update is called once per frame
    void Update()
    {
        //difference = Mathf.Abs(hero.transform.position.x - beforePosition);
        //animator.SetFloat("transition", difference);
        animator.SetBool("ifMove", move);
        animator.SetBool("touchGround", touchGround);
        CheckMovement();
    }
}
