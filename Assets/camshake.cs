using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camshake : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void startshake(float duration, float magnitude){
        Debug.Log("this was called");
        float d = duration;
        float m = magnitude;
        StartCoroutine(Shake(d,m));
    }
    public void Update()
    {

    }
    IEnumerator Shake(float duration,float magnitude) {
        Debug.Log("this was also called");
        Vector3 orignalpos = transform.localPosition;
        float elapsedtime = 0.0f;
        while (elapsedtime< duration) 
        {
            float x = Random.Range(-1   , 1) * magnitude;
            float y = Random.Range(-1, 1) * magnitude;
            transform.localPosition = new Vector3(x, y, orignalpos.z);
            elapsedtime += Time.deltaTime;
            Debug.Log("allfunctions here executed");
            yield return null;
        }
        transform.localPosition = orignalpos;
    }
}
