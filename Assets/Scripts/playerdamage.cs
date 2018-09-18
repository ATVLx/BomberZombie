using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdamage : MonoBehaviour {
    public GameObject player;
    public Animator anim;
	// Use this for initialization
	void Start () {
        //anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OncollisionEnter(Collision tag)
    {
        if (tag.gameObject.tag == "bomb")
        {
            Debug.Log("deadbomb");
        }
        if (tag.gameObject.tag == "Enemy")
        {
            Debug.Log("deadEnemy");
        }
    }
         void OnTriggerEnter(Collider collison)
    {
        if (collison.tag == "bomb")
        {
            Debug.Log("bomb hit" );
            //player.SetActive(false);
            // Destroy(collison.gameObject);
            // Destroy(gameObject);
            FindObjectOfType<playercontroller>().Dieactivator();
            FindObjectOfType<playercontroller>().animationdie();
            anim.SetBool("die1", true);
        }
        if (collison.tag == "Enemy")
        {
            Debug.Log("enemy hit");
            anim.SetTrigger("die");
         //   Destroy(collison.gameObject);
           // Destroy(gameObject);
        }
    }

    }

