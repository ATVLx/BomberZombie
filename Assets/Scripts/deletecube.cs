using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deletecube : MonoBehaviour {

    float timeLeft;
    public Renderer rend;
    Color targetColor;
	// Use this for initialization
	void Start () {
        StartCoroutine(deletecubefn());
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (timeLeft <= Time.deltaTime)
        {
            // transition complete
            // assign the target color
            rend.material.color = targetColor;

            // start a new transition
            targetColor = new Color(Random.value, Random.value, Random.value);
            timeLeft = 1.0f;
        }
        else
        {
            // transition in progress
            // calculate interpolated color
            rend.material.color = Color.Lerp(rend.material.color, targetColor, Time.deltaTime / timeLeft*2);

            // update the timer
            timeLeft -= Time.deltaTime;
        }

	
	}
    IEnumerator deletecubefn()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
