using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicbrick : MonoBehaviour
{
    public GameObject portal;
    public GameObject magicbrickpos;
    Vector3 pos;
    // public GameObject brick;
    // Use this for initialization
    void Start()
    {
        pos =  magicbrickpos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider collison)
    {
        if (collison.tag == "bomb")
        {
            Instantiate(portal, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            Debug.Log("calledfor delete");
            Destroy(collison.gameObject);
            Destroy(gameObject);
        }
        if (collison.tag == "fire")
        {
            Debug.Log("calledfor delete");
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
