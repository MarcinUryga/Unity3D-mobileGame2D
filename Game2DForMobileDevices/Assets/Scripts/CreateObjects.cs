using UnityEngine;
using System.Collections;

public class CreateObjects : MonoBehaviour
{
    public GameObject objectsToCreate;
    public GameObject hero;
    public int numberOfCreateObjects;
    private int i = 0;

    // Use this for initialization
    void Start()
    {
        hero = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if ((gameObject.transform.position.x - hero.transform.position.x < 100) && i < numberOfCreateObjects)
        {
            GameObject.Instantiate(objectsToCreate, new Vector3(gameObject.transform.position.x + 2, gameObject.transform.position.y, gameObject.transform.position.z), gameObject.transform.localRotation);
            i++;
        }
    }
}
