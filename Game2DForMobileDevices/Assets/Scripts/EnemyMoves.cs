using UnityEngine;
using System.Collections;

public class EnemyMoves : MonoBehaviour
{
    private Rigidbody2D enemy;

    public LayerMask layer;
    public Transform obstacleSensor;
    public float radiusOfObstacleSensor;
    public float Speed;
    public float direction = 1;

    public bool withGun;

    // Use this for initialization
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
    }

    void SetDirection()
    {
        if (Physics2D.OverlapCircle(obstacleSensor.position, radiusOfObstacleSensor, layer))
        {
            direction *= -1;
            enemy.transform.localScale = new Vector3(direction, 1, 1);
        }
    }

    void EnemyMoveFunction()
    {
        SetDirection();
        if (enemy.transform.localScale.x == 1)
        {
            enemy.velocity = new Vector2(-Speed, enemy.velocity.y);
        }
        else
        {
            enemy.velocity = new Vector2(Speed, enemy.velocity.y);
        }
    }

    
   

    // Update is called once per frame
    void Update()
    {
        EnemyMoveFunction();
    }
}
