using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



    public class bombscript : MonoBehaviour
    {
        public Material mat;
        public Color newcolor;
        public KeyCode changecolor;
        public GameObject bomb;
        public int bombsize = 2;
        public GameObject position;
        public GameObject player;
        public GameObject cube;
        public AudioSource bombaudio;
    public float timetoexplo=3;
    public TextMeshProUGUI bombtimer;
    public playerchasecam camshake1;
    public float magnitude=0.15f;
    public float shakeduration=2f;
    public camshake camsh;


    //==================================  ============== ===================\\
       
        void Start()
        {
            bombsize = 2;
            // StartCoroutine(changecolor2());
            StartCoroutine(waitforexplode());
            //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            StartCoroutine(changecolor2());
        }













        // Update is called once per frame
        void Update()
        {

        bombtimer.text = timetoexplo + "";

            // changecolor2();
            if (Input.GetButtonDown("Horizontal"))
            {
                Debug.Log("buttoncalled");
                dropbomb();
                StartCoroutine(changecolor2());
                Debug.Log("buttoncalled");
            }
            if (Input.GetMouseButtonDown(0))
            {
                //exploision();
            }

            if (Input.GetMouseButtonDown(1))
                Debug.Log("Pressed secondary button.");

            if (Input.GetMouseButtonDown(2))
                Debug.Log("Pressed middle click.");
        }


        IEnumerator changecolor2()
        {
        Vector3 scale= new Vector3(0.5f, .7f, .7f);
        transform.localScale += -Time.timeScale* scale;
            yield return new WaitForSeconds(0.3f);
            mat.color = Color.white;
            StartCoroutine(changecolor1());

        }
        IEnumerator changecolor1()
        {
        Vector3 scale = new Vector3(0.5f, .7f, .7f);
        transform.localScale += Time.timeScale * scale;
        yield return new WaitForSeconds(0.3f);
            mat.color = Color.red;
            StartCoroutine(changecolor2());

        }
        IEnumerator waitforexplode()
        {

            yield return new WaitForSeconds(1);
        if(timetoexplo == 0.0f) 
        {   
            exploision();

        }
        if(timetoexplo!=0){
            timetoexplo--;
            StartCoroutine(waitforexplode());
        }
        if(timetoexplo<-2){
            timetoexplo = 0;
            yield return null;

        }


           
        }
        public void dropbomb()
        {
            Debug.Log("dropbombcalled");
            Vector3 pos1 = player.transform.position; ;
            Instantiate(bomb, new Vector3(pos1.x, pos1.y, pos1.z), Quaternion.identity);
                    StartCoroutine(waitforexplode());
            exploision();
        }
        public void exploision()
        {
            bomb.transform.position = position.transform.position;
            Vector3 pos = bomb.transform.position;
        bombaudio.Play();
        Debug.Log("blast");
        FindObjectOfType<GameManager>().Explodbomb();
        //camera effect
            for (int i = 0; i <= bombsize; i++)
            {
                // Instantiate(bomb, new Vector3(i , 0, 0), Quaternion.identity);
                //Instantiate(bomb, new Vector3(-i, 0, 0), Quaternion.identity);
                Instantiate(bomb, new Vector3(pos.x + i, 0.7751395f, pos.z), Quaternion.identity);
                Instantiate(bomb, new Vector3(pos.x, 0.7751395f, pos.z + i), Quaternion.identity);
                Instantiate(bomb, new Vector3(pos.x - i, 0.7751395f, pos.z), Quaternion.identity);
                Instantiate(bomb, new Vector3(pos.x, 0.7751395f, pos.z - i), Quaternion.identity);

                Instantiate(cube, new Vector3(pos.x + (i * 0.75f), 0.7751395f, pos.z), Quaternion.identity);
                Instantiate(cube, new Vector3(pos.x, 0.7751395f, pos.z + (i * 0.75f)), Quaternion.identity);
                Instantiate(cube, new Vector3(pos.x - (i * 0.75f), 0.7751395f, pos.z), Quaternion.identity);
                Instantiate(cube, new Vector3(pos.x, 0.7751395f, pos.z - (i * 0.75f)), Quaternion.identity);

                StartCoroutine(waitformemorydelete());

        }

      
        return;
        }
        IEnumerator waitformemorydelete()
        {
            yield return new WaitForSeconds(2.2f);
            //Destroy(bomb);
            //Destroy(position);
            //Destroy(cube);
        }
        public float OnUpdateBombSize(int size)
        {
            
            bombsize += size;
            Debug.Log("bombsize is: " + bombsize);
            
        FindObjectOfType<playercontroller>().info1();
        return bombsize;

    }




    }


