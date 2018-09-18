using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickscript : MonoBehaviour
{
    // public GameObject brick;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider collison)
    {
        if (collison.tag == "bomb")
        {
            //Debug.Log("calledfor delete");
            Destroy(collison.gameObject);
            Destroy(gameObject);
        }
        if (collison.tag == "fire")
        {
            //Debug.Log("calledfor delete");
            Destroy(collison.gameObject);
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "bomb")
        {
            Destroy(col.gameObject);
        }
    }
}
