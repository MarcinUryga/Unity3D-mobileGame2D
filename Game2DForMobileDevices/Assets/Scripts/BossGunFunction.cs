using UnityEngine;
using System.Collections;

public class BossGunFunction : MonoBehaviour
{
    public float attacfreq;
    public GameObject ammo;

    float lastAttack;

    // Use this for initialization
    void Start()
    {
        lastAttack = 0;
    }

    void Attack()
    {
        if (Time.time - lastAttack < attacfreq)
            return;

        GameObject.Instantiate(ammo, new Vector3(transform.position.x - 2.1f, transform.position.y - 0.3f, transform.position.z), transform.localRotation);
       // _ammo.verticalDirection = true;

        lastAttack = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
}
