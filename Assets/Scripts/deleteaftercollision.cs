using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteaftercollision : MonoBehaviour {
    public GameObject magicbricktohide;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider collison)
    {
        if (collison.tag == "Player")
        {

            Debug.Log("hidding it");
            magicbricktohide.SetActive(false);
           // StartCoroutine(hidinginfewsec());
        }
    }
    IEnumerator hidinginfewsec()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        magicbricktohide.SetActive(false);
    }
}
