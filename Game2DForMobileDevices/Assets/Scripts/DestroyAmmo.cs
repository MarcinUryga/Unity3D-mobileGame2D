using UnityEngine;
using System.Collections;

public class DestroyAmmo : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "ammo(Clone)" || col.name == "ammo 1(Clone)")
        {
            Destroy(col.gameObject);
        }
    }
}
