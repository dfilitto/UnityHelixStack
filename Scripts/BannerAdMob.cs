using System;
using UnityEngine;
using GoogleMobileAds.Api;
//using UnityEditor.PackageManager.Requests;

public class BannerAdMob : MonoBehaviour
{
    private BannerView bannerView;
    // Start is called before the first frame update
    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { Debug.Log("initStatus: " + initStatus.ToString()); });
        //this.RequestBanner();
    }

    public void RequestBanner()
    {
#if UNITY_ANDROID
        // Trocar o adUnitId para o seu obtido no admob
        string adUnitId = "ca-app-pub-3425430436654376/1403222875";
        #elif UNITY_IPHONE
                    string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        #else
                    string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }

}
