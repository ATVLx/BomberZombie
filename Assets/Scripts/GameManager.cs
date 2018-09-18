using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using EZCameraShake;

public class GameManager : MonoBehaviour
{
    public AudioSource maingamemusic;
    public AudioSource explod;
    public AudioSource gameoversound;
    public AudioSource menusound;
    public GameObject Pausepanel;
    public GameObject pauseBTn;
    public GameObject gameOverPanel;
    public TextMeshProUGUI timetext;
    public int Gametime = 70;
    public GameObject mute;
    public GameObject unmute;
    public GameObject touchpanel;
    public GameObject joystickcontroller;
    public TextMeshProUGUI stageDisplay;
    public GameObject BossStageDisplay;
    public GameObject stagedisplaypanel;
    public GameObject mapbtn;
    public GameObject largemap;
    public GameObject restartforONEUP;
    public GameObject Player;
    public bool oneUPtaken = false;
    public float magnitude = 0.15f;
    public float shakeduration = 2f;
    public GameObject FadeIn;
    public GameObject FadeOut;
    // Use this for initialization
    void Start()
    {
        FadeOut.SetActive(false);
        FadeIn.SetActive(true);
        OnstageSHow();
        Time.timeScale = 1;
        StartCoroutine(Timewait());
        joystickcontroller.SetActive(true);
        touchpanel.SetActive(true);
        restartforONEUP.SetActive(false);
        oneUPtaken = false;


        // explod = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Gametime == 0 || Gametime < 0)
        {
            GameOverPanelDisplay();
            Gameoverfx();
        }
        timetext.text = Gametime + " Sec";

        if(oneUPtaken == true )
        {
            restartforONEUP.SetActive(true);
        }
        if (oneUPtaken == false)
        {
            restartforONEUP.SetActive(false);
        }
    }
    public void Gameoverfx()
    {
        Time.timeScale = 0;
        //gameoversound.Play();

    }
    public void Explodbomb()
    {
        explod.Play();
        //FindObjectOfType<camshake>().startshake(shakeduration,magnitude);
       // FindObjectOfType<playerchasecam>().startshake(shakeduration, magnitude);
       // CameraShaker.Instance.ShakeOnce(4f,4f,1f,1f);
    }
    public void GameoverSound()
    {
        maingamemusic.Stop();
        gameoversound.Play();
    }
    public void Ongamepause()
    {
        menusound.Play();
        maingamemusic.Stop();
        pauseBTn.SetActive(false);
        Pausepanel.SetActive(true);
        Time.timeScale = 0;
        touchpanel.SetActive(false);
        //StartCoroutine();
    }
    IEnumerator Timewait()
    {
        yield return new WaitForSeconds(1f);
        Gametime--;
        StartCoroutine(Timewait());
        if(Gametime == 0 ||Gametime < 0) {
            yield return null;
        }
    }

    public void onexpandmap()
    {
        //mapbtn.SetActive(false);
        largemap.SetActive(true);

    }
    public void OnMapBackBtn()
    {
        largemap.SetActive(false);

    }

    public void GameOverPanelDisplay()
    {
        GameoverSound();
        gameOverPanel.SetActive(true);

       

        StartCoroutine(waitforgameover());
        touchpanel.SetActive(false);
        pauseBTn.SetActive(false);
        joystickcontroller.SetActive(false);
        if (oneUPtaken == true)
        {
            restartforONEUP.SetActive(true);
        }

        // Gameoverfx();
    }

    public void onOneUPUPdate(){

        oneUPtaken = true;
        restartforONEUP.SetActive(true);
    }

    public void OneUpResume(){
        Player.SetActive(true);
        Player.transform.position = new Vector3(-6.93f, 0.37f, 6.89f);
        gameOverPanel.SetActive(false);
        Time.timeScale=1;
    }


    public void OnbackBtnClick()
    {
        Time.timeScale = 1;
        menusound.Stop();
        maingamemusic.Play();
        //gameOverPanel.SetActive(false);
        Pausepanel.SetActive(false);
        pauseBTn.SetActive(true);
        touchpanel.SetActive(true);
        joystickcontroller.SetActive(false);
    }
    public void OnRestartClick()
    {
        int a;
        a = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(a);
        joystickcontroller.SetActive(true);
        Admanager.Instance.ShowVideo();
    }
    public void OnReSUMEclicK()
    {
        pauseBTn.SetActive(true);
        Time.timeScale = 1;
        //gameOverPanel.SetActive(false);
        Pausepanel.SetActive(false);
        pauseBTn.SetActive(true);
        Time.timeScale = 1;
        Time.timeScale = 1;
        Time.timeScale = 1;
        Time.timeScale = 1;
        Time.timeScale = 1;
        Player.SetActive(true);
        pauseBTn.SetActive(true);
        if(Player.activeSelf==false){
            Player.SetActive(true);

        }
    }
    public void OnQuitApplicationClick(){
        Application.Quit();
        Debug.Log("Application QuitBTN Called");
    }
    public void OnQuitClick(){
        SceneManager.LoadScene("ARBBM");
    }
    public void OnMuteClick(){
        unmute.SetActive(true);
        mute.SetActive(false);
        AudioListener.volume = 0;
    }
    public void OnUnmuteClick()
    {
        unmute.SetActive(false);
        mute.SetActive(true);

        AudioListener.volume = 1;
    }
    IEnumerator waitforgameover()
    {

        //animationdie();
        //player.SetActive(false);


        yield return new WaitForSeconds(3);
        Gameoverfx();
        if(oneUPtaken == true) {
        restartforONEUP.SetActive(true);
        }
        if(oneUPtaken == false) 
        {
            restartforONEUP.SetActive(false);
        }
        Player.SetActive(false);
        Admanager.Instance.ShowVideo();


    }
    public void OnstageSHow()
    {
        int a;
      a =  SceneManager.GetActiveScene().buildIndex;
        stageDisplay.text = "Stage: " + a;
        StartCoroutine(waitforhide());


        
    }
    IEnumerator waitforhide(){
        yield return new WaitForSeconds(3f);
        FadeIn.SetActive(false);
        stagedisplaypanel.SetActive(false);
        BossStageDisplay.SetActive(false);

    }
}

