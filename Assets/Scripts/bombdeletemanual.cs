using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombdeletemanual : MonoBehaviour
{
    //public float timetodestroy = 3.0f;
    // Use this for initialization
    void Start()
    {
       // StartCoroutine(waitforunloaddelete());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator waitfordelete() {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    public void Deletebombmanually()
    {
        StartCoroutine(waitfordelete());

    }
}
