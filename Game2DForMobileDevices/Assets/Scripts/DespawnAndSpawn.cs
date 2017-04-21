using UnityEngine;
using System.Collections;

public class DespawnAndSpawn : MonoBehaviour
{
    public Transform Spawn;
    public Transform Despawn;

    private GameObject _hero;
    // Use this for initialization
    void Start()
    {
        _hero = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Spawn.transform.position = new Vector2(_hero.transform.position.x + 50, _hero.transform.position.y);
        Despawn.transform.position = new Vector2(_hero.transform.position.x - 50, _hero.transform.position.y);
        if (transform.position.x <= Despawn.transform.position.x)
            transform.position = new Vector3(Spawn.position.x-3, Random.Range(_hero.transform.position.y - 14f, _hero.transform.position.y + 14f), 1);
    }
}
