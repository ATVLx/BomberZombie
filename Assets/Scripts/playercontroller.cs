using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class playercontroller : MonoBehaviour
{
    public FloatingJoystick joy;
    //Touch initouch = new Touch();
    public Camera cam;
    //float rotX = 0.0f;
    //float RotY = 0.0f;
    //float rotcamspeed = 0.5f;
    //float direction = -1;
    private Vector3 OrignalRot;
    public Virtualjoystick joystick;
    public Virtualjoystick joystick1;
    public Vector3 axis;
    public Joystick joy1;
    public float lookspeed=200;
    public AudioSource running;
    public AudioSource powerup;

    // Use this for initialization

   
    public NavMeshAgent agent;
    public GameObject player;
    public GameObject bomb;
    public GameObject marker;
    float timeLeft;
    public Renderer rend;
    Color targetColor;
    public Animator animator;
    bool die;
    public bool gameover = false;
    bool pickedup = false;
    GameManager manager;
    public int remainingenemy = 2;
    public TextMeshProUGUI displaytext;
    public TextMeshProUGUI info;
    public float speedofcharacter = 10f;
    public float rotationofCharater = 100f;
    public GameObject infotext;
    public GameObject manualbomb;
    public GameObject muanualbombbtn;
    public GameObject normalbombbtn;
    public GameObject explodebombbtn;
    public Animator fadeOutAnim;
    public GameObject Fadeout;

    Rigidbody rb;
    void Start()
    {
        Fadeout.SetActive(false);
        rb = GetComponent<Rigidbody>();
        // displaytext = GetComponent<TextMeshProUGUI>();

        animator = GetComponent<Animator>();
        die = false;
       
    }





   




    private void FixedUpdate()
    {
        //nothins here
    }


    // Update is called once per frame
    void Update()
    {
        float rotation;
       // float translation = Input.GetAxis("Vertical") * speedofcharacter;
       // float h = Input.GetAxis("Vertical") * speedofcharacter;
       // float rotation = Input.GetAxis("Horizontal") * rotationofCharater;
        float translation = joystick.Vertical() * speedofcharacter;
        float h = joystick.Vertical() * speedofcharacter;
       // float rotation = joystick.Horizontal() * rotationofCharater;
         rotation = joy.Horizontal1() * rotationofCharater;
        if(joystick.Horizontal()>0 || joystick.Horizontal()<0){
            rotation = joystick.Horizontal() * rotationofCharater;
        }
        if (joy.Horizontal1() > 0 || joy.Horizontal1() < 0)
        {
            rotation = joy.Horizontal1() * lookspeed;
        }
        //  Debug.Log("Translation: "+translation);
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        Vector3 rotate3d = new Vector3(0, rotation, 0);
        transform.Rotate(0, rotation, 0);
        Vector3 moveforward = new Vector3(0, 0, translation);
        //Debug.Log(moveforward);
        if (h > 0 || h < 0)
        {

            animator.SetTrigger("running 0");
          
           // running.Play();
      

        }
        if(h==0){

            animator.SetTrigger("idle1");
           // running.Stop();
        }
        if (h > 0 || h < 0)
        {
            if(running.isPlaying){
                return;
            }
            running.Play();
            //Debug.Log("Audio runnning Played");
        }
        if (h == 0)
        {
            running.Stop();
            //Debug.Log("Audio runnning stopped");
        }

        //rb.MovePosition(new Vector3(0, 0, translation) * Time.deltaTime);
        // rb.AddForce(moveforward);
        //
        //Quaternion deltaRotation = Quaternion.Euler(rotate3d*20 * Time.deltaTime);
        //rb.MoveRotation(rb.rotation  *  deltaRotation);
        //.MovePosition(moveforward);


        /*
        if (Input.GetButton("Vertical"))
        {
            float v = Input.GetAxis("Vertical");
            //transform.Translate(0, 0, 0.1f);
            if (v > 0)
            {
                transform.Translate(0, 0, 0.1f);
            }
            if (v < 0)
            {
                transform.Translate(0, 0f, -0.1f);
            }
            //transform.rotation = Quaternion.identity;
        }
        if (Input.GetButton("Horizontal"))
        {
            float h = Input.GetAxis("Horizontal");
            //transform.Translate(0, 0, 0.1f);
            if(h>0){
                transform.Rotate(0, 1f, 0);
            }
            if (h < 0)
            {
                transform.Rotate(0, -1f, 0);
            }

        }















        /* if (Input.GetMouseButtonDown(0))
         {
             Ray r = cam.ScreenPointToRay(Input.mousePosition);
             RaycastHit hit;

             if (Physics.Raycast(r, out hit))
             {

                 //animator.SetBool("idle", false);
                 agent.SetDestination(hit.point);
                 Vector3 pos = hit.point;
                 Instantiate(marker, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
                 //Debug.Log(hit.point);
                 pathComplete();
                 /* if (agent.hasPath || agent.velocity.sqrMagnitude > 0f)
                  {
                      Debug.Log("running");
                      animator.SetTrigger("running 0");
                      animator.SetBool("idle", false);
                      animator.SetBool("running", true);
                  }


                      if (agent.remainingDistance <= agent.stoppingDistance)
                      {
                          if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                          {
                              Debug.Log("idle");
                              //animator.SetBool("running", false);
                              animator.SetTrigger("idle1");
                              animator.SetBool("idle", true);

                          }

                      }*

             }

         }

         {
             pathComplete();



                 if (pathComplete())
                 {
                     //Debug.Log("idle");
                     animator.SetTrigger("idle1");
                     if (player.transform.position == agent.destination)
                     {
                         //Debug.Log("reached checkpoint0");
                         //Debug.Log("playerpos reached idle idel");
                         animator.SetTrigger("idle1");
                     }
                 }
                 //else animator.SetTrigger("running 0");


                 if (!pathComplete())
                 {

                     //Debug.Log("running");
                     animator.SetTrigger("running 0");
                     if (player.transform.position == agent.destination)
                     {
                       //  Debug.Log("reached checkpoint1");
                         //Debug.Log("playerpos reached idle running");
                         animator.SetTrigger("idle1");
                     }

                 }
                 //if (animationdie()) { return; }
                 else animator.SetTrigger("idle1");

                 if (player.transform.position == agent.destination)
                 {
                     //Debug.Log("reached checkpoint2");
                     // Debug.Log("playerpos reached");
                     animator.SetTrigger("idle1");
                 }

             }
         }*/
    }


    public int Enemyremainingatscene(int enemystatus)
    {
        remainingenemy -= enemystatus;
        Debug.Log("remaining enemy: "+remainingenemy);
        displaytext.text = "remaining enemy: "+ remainingenemy;
        if(remainingenemy==0){
            displaytext.text = "Get to the Portal";
        }
        return remainingenemy;
        
    }

    public void dropbomb()
    {
        //Debug.Log("dropbombcalled");
        /*Vector3 pos1 = player.transform.position; ;
        Instantiate(bomb, new Vector3(pos1.x-0.1f, pos1.y, pos1.z), Quaternion.identity);*/
        animator.SetTrigger("PlantBomb");
        StartCoroutine(waitforplantbomb());

        //        StartCoroutine(waitforexplode());
       
    }

    protected bool pathComplete()
    {
        if (Vector3.Distance(agent.destination, agent.transform.position) <= agent.stoppingDistance)
        {
           // animator.SetTrigger("running 0");
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
            {
                //animator.SetTrigger("idle1");
                return true;
            }
        }

        return false;
    }
    IEnumerator waitforplantbomb(){
        Quaternion rot = new Quaternion(180, 0, 0,2.1f);
        yield return new WaitForSeconds(0.5f);
        Vector3 pos1 = player.transform.position; ;
        Instantiate(bomb, new Vector3(pos1.x - 0.1f, pos1.y+ 0.36513f, pos1.z),Quaternion.identity * rot);
        animator.SetTrigger("idle1");

    }
    IEnumerator Waitformanualplantbomb()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 pos1 = player.transform.position; ;
        Instantiate(manualbomb, new Vector3(pos1.x - 0.1f, pos1.y + 0.36513f, pos1.z), Quaternion.identity);
        animator.SetTrigger("idle1");

    }


    void OnTriggerEnter(Collider collison)
    {
        if (collison.tag == "bomb")
        {

            Debug.Log("bomb hit");
            //player.SetActive(false);
            animationdie();
            animator.SetBool("die1", true);


            StartCoroutine(waitforgameover());
           // FindObjectOfType<GameManager>().GameoverSound();

            //FindObjectOfType<GameManager>().Gameoverfx();
          
            //StartCoroutine(waitforgameover());
            // Destroy(collison.gameObject);
            // Destroy(gameObject);
        }
        if (collison.tag == "portal")
        {
            if (remainingenemy == 0)
            {
                Fadeout.SetActive(true);
                Debug.Log("Portal hit");
                StartCoroutine(WaitfornextStage());
               

            }
        }
        if (collison.tag == "bombexpand")
        {
            //int a = 1;
            
            Debug.Log("expandbrickpickedup");
            powerup.Play();
            onupdatebomb();

        }
        if (collison.tag == "speedup")
        {
            //int a = 1;
            Debug.Log("speedup taken");
            // Debug.Log("expandbrickpickedup");
            onUpdateSpeedofCharacter();
            powerup.Play();
            info2();
           // onupdatebomb();
        }
        if (collison.tag == "OneUP")
        {
            //int a = 1;
           //Debug.Log("speedup taken");
            // Debug.Log("expandbrickpickedup");
            //onUpdateSpeedofCharacter();
            powerup.Play();
            info4();
            FindObjectOfType<GameManager>().onOneUPUPdate();
            // onupdatebomb();
        }

        if (collison.tag == "manualexplo")
        {
            //int a = 1;
            Debug.Log("manualbombexplo taken");
            explodebombbtn.SetActive(true);
            normalbombbtn.SetActive(false);
            muanualbombbtn.SetActive(true);
            powerup.Play();
            info3();

           
        }

        if (collison.tag == "Enemy")
        {
           // Debug.Log("enemy hit");
            die = true;
            animationdie();
            FindObjectOfType<GameManager>().GameoverSound();
            //FindObjectOfType<GameManager>().gameoverfx();
            //StartCoroutine(waitforgameover());
            //   Destroy(collison.gameObject);
            // Destroy(gameObject);
        }
    }


    IEnumerator WaitfornextStage(){
      


        yield return new WaitForSeconds(2);
        int a;
        a = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(a + 1);
    }


    public void onUpdateSpeedofCharacter() {
        speedofcharacter += 0.5f;
    }

    public void info1() {

        infotext.SetActive(true);
        info.text = "Bomb Expaned";
        StartCoroutine(waitfortexthide());
        
    }
    public void info2()
    {

        infotext.SetActive(true);
        info.text = "Speed Increased";
        StartCoroutine(waitfortexthide());

    }
    public void info3()
    {

        infotext.SetActive(true);
        info.text = "Remote Control bomb";
        StartCoroutine(waitfortexthide());

    }
    public void info4()
    {

        infotext.SetActive(true);
        info.text = "1-UP";
        StartCoroutine(waitfortexthide());

    }

    IEnumerator waitfortexthide(){
        yield return new WaitForSeconds(3);
        infotext.SetActive(false);

    }


    void onupdatebomb()
    {
        if (!pickedup)
        {
            int a =2;
            bomb.GetComponent<bombscript>().OnUpdateBombSize(a);
            Debug.Log(a);
            pickedup = true;
        }
    }
    public bool animationdie()
    {
        if (die)
        {
            animator.SetTrigger("die");
            animator.SetBool("die1",true);
            StartCoroutine(waitforgameover());
            return true;
        }
        else return false;
    }
    IEnumerator waitforgameover()
    {
        yield return new WaitForSeconds(2);
        //animationdie();
        //player.SetActive(false);
        FindObjectOfType<GameManager>().GameOverPanelDisplay();


       
       

    }
    public void  Dieactivator(){
        die = true;  //this is called by playerDamage.cs script
    }


    public void Dropmanualbomb(){
        animator.SetTrigger("PlantBomb");
        StartCoroutine(Waitformanualplantbomb());
    }

    public void OnExplodeMAnually(){
        FindObjectOfType<bombscript1>().exploision();
        FindObjectOfType<bombdeletemanual>().Deletebombmanually();
    }

}
