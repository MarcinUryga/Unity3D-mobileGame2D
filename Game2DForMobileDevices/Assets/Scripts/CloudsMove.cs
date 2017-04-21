using UnityEngine;
using System.Collections;

public class CloudsMove : MonoBehaviour
{
    private float Speed;
    
    // Use this for initialization
    void Start()
    {
        Speed = Random.Range(-0.02f, -0.08f);
        if (gameObject.name.Contains("Clone"))
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Speed, 0, 0);
    }
}
