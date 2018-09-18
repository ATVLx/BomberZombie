using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;

public class Admanager : MonoBehaviour
{
    public string bannerID;
    public string VideoID;


    public static Admanager Instance { get; set; }
    // Use this for initialization
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
#if UNITY_EDITOR
        Debug.Log("i wont run under unity Console");
#elif UNITY_ANDROID

        Admob.Instance().initAdmob(bannerID, VideoID);
        Admob.Instance().loadInterstitial();
        ShowBanner();
#endif
    }

    public void ShowBanner()
    {
#if UNITY_EDITOR
        Debug.Log("cannotplayInterstitial bcoz of Unity Engine");
#elif UNITY_ANDROID
        Admob.Instance().showBannerAbsolute(AdSize.Banner,AdPosition.TOP_CENTER,5);
#endif

    }
    public void ShowVideo()
    {
        #if UNITY_EDITOR
#elif UNITY_ANDROID
        if(Admob.Instance().isInterstitialReady()){
            Admob.Instance().showInterstitial();
        }
#endif
    }
	// Update is called once per frame
	void Update () {
		
	}
}
