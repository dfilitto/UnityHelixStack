using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class InterstitialAdMob : MonoBehaviour
{
    private InterstitialAd interstitial;

    // Start is called before the first frame update
    public void StartVideo()
    {
        
        MobileAds.Initialize(initStatus => { });
        RequestInterstitial();

        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        // Trocar o adUnitId para o seu obtido no admob
        string adUnitId = "ca-app-pub-3425430436654376/3837814524";
        #elif UNITY_IPHONE
                string adUnitId = "ca-app-pub-3940256099942544/4411468910";
        #else
                string adUnitId = "unexpected_platform";
        #endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }
}
