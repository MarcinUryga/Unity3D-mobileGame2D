using UnityEngine;
using System.Collections;

public class BossMove : MonoBehaviour
{
    public Rigidbody2D boss;
    public float Speed;
    public bool rightSensor, leftSensor;
    public Transform obstaclesSensorR, obstaclesSensorL;
    public float radiusOfSensor;
    public LayerMask layer;
    private bool turnLeft, turnRight;

    // Use this for initialization
    void Start()
    {
        boss = GetComponent<Rigidbody2D>();
        turnLeft = true;
        turnRight = false;
    }

    void Move()
    {
        if (turnRight) boss.velocity = new Vector2(Speed, boss.velocity.y);
        if (turnLeft) boss.velocity = new Vector2(-Speed, boss.velocity.y);
    }
    void FixedUpdate()
    {
        if (rightSensor = Physics2D.OverlapCircle(obstaclesSensorR.position, radiusOfSensor, layer))
        {
            turnLeft = true;
            turnRight = false;
        }

        if (leftSensor = Physics2D.OverlapCircle(obstaclesSensorL.position, radiusOfSensor, layer))
        {
            turnLeft = false;
            turnRight = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
