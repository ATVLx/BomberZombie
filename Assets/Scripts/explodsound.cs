using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodsound : MonoBehaviour {
    AudioSource explod;
	// Use this for initialization
	void Start () {
        explod = GetComponent<AudioSource>();
        explod.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
