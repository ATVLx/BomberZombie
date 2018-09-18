using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deletebomb : MonoBehaviour {
    public float timetodestroy = 3.0f;
	// Use this for initialization
	void Start () {
        StartCoroutine(waitforunloaddelete());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator waitforunloaddelete()
    {
        yield return new WaitForSeconds(timetodestroy);
        Destroy(gameObject);
    }
}
