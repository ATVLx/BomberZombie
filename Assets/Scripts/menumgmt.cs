using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.PostProcessing;

public class menumgmt : MonoBehaviour
{
    public Animator anim;
    public Animator fadeanim;
   // bool isplaying = false;
    public Gamesettings gamesettings;
    public GameObject playbtn;
    public GameObject options;
    public GameObject qualitylevel;
    public GameObject graphictext;
    public GameObject backbtn;
    public GameObject Quitbtn;
    public GameObject mute;
    public GameObject unmute;
    public GameObject bloomtext;
    public GameObject bloomslider;
    public GameObject ambientocltxt;
    public GameObject ambientslider;
    public GameObject toggle;
    public GameObject fadeout;



    public float bloom = 10f;
    public float saturation = 5f;

    public PostProcessingProfile ppProfile;

    void onEnable()
    {
        gamesettings = new Gamesettings();
    }
    public void ontexturechange(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);

    }
    // Use this for initialization
    void Start()

    {
        //Admanager.Instance.ShowInterstitial();
        Admanager.Instance.ShowBanner();
        Time.timeScale = 1.1f;
        playbtn.SetActive(true);
        options.SetActive(true);
        Quitbtn.SetActive(true);
        //ChangeBloomAtRuntime();
    }
    /*void ChangeBloomAtRuntime()
    {
        //copy current bloom settings from the profile into a temporary variable
        BloomModel.Settings bloomSettings = ppProfile.bloom.settings;

        //change the intensity in the temporary settings variable
        bloomSettings.bloom.intensity = 2;

        //set the bloom settings in the actual profile to the temp settings with the changed value

    }*/


    public void SetBloom(float intensity)
    {
        //Debug.Log("intensity: " + intensity);
        BloomModel.Settings bloomSettings = ppProfile.bloom.settings;
        bloomSettings.bloom.intensity = intensity * 10;
        ppProfile.bloom.settings = bloomSettings;
        AmbientOcclusionModel.Settings ABOCL = ppProfile.ambientOcclusion.settings;
        ABOCL.intensity = intensity;
    }
    public void toggleambientocl (float ambientoCL)
    {
        AmbientOcclusionModel.Settings ABOCL = ppProfile.ambientOcclusion.settings;
       // ABOCL.ambientOcclusion.intensity = ambientoCL;
       // VignetteModel.Settings bgn = ppProfile.vignette.settings;
        ABOCL.intensity = ambientoCL*10;
        ppProfile.ambientOcclusion.settings = ABOCL;
    }
    public void onAntiailisingEffects(bool Ailising)
    {
        if (Ailising == true){

        
        ppProfile.antialiasing.enabled= true;
        }
        if (Ailising == false)
        {


            ppProfile.antialiasing.enabled = false;
        }

    }


// Update is called once per frame
void Update () {
		
	}
    public void OnPlayClick()
    {
        anim.SetTrigger("cameraexit");
        StartCoroutine(waitfortransit());
        playbtn.SetActive(false);
        options.SetActive(false);
        Quitbtn.SetActive(false);
        StartCoroutine(waitforfadeout());

        
        // SceneManager.LoadScene("Bomberman");
    }
    public void OnOptionsClick()
    {
        playbtn.SetActive(false);
        options.SetActive(false);
        qualitylevel.SetActive(true);
        graphictext.SetActive(true);
        backbtn.SetActive(true);
        Quitbtn.SetActive(false);
        mute.SetActive(true);
        ambientocltxt.SetActive(true);
        bloomtext.SetActive(true);
     bloomslider.SetActive(true); 
     ambientocltxt.SetActive(true); 
     ambientslider.SetActive(true);
        toggle.SetActive(true);

}
    public void OnBACKbtnClick()
    {
        playbtn.SetActive(true);
        options.SetActive(true);
        qualitylevel.SetActive(false);
        graphictext.SetActive(false);
        backbtn.SetActive(false);
        Quitbtn.SetActive(true);
        mute.SetActive(false);
        unmute.SetActive(false);
        ambientocltxt.SetActive(false);
        bloomtext.SetActive(false);
        bloomslider.SetActive(false);
        ambientocltxt.SetActive(false);
        ambientslider.SetActive(false);
        toggle.SetActive(false);

    }

    IEnumerator waitfortransit()
    {
        
       /* while (!anim.IsInTransition(0))
        {
          
            yield return null;
            SceneManager.LoadScene("Bomberman");
            
        }*/
        do


            yield return null;

        while (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1 || anim.IsInTransition(0));
        {
            fadeout.SetActive(true);
            Debug.Log("isplaying");
            yield return null;
            StartCoroutine(waitforfadeout());

            //SceneManager.LoadScene("Bomberman");
        }
        fadeout.SetActive(true);
        Debug.Log("complete");
        SceneManager.LoadScene("Bomberman");
        
        //yield return new WaitForSeconds(5f);
        
    }



    IEnumerator waitforfadeout()
    {

        /* while (!anim.IsInTransition(0))
*/

        //fadeout.SetActive(true);
        yield return new WaitForSeconds(1);
        //fadeanim.SetTrigger("stagechange");
        fadeout.SetActive(true);

    }


    public void OnMuteClick()
    {
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
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
