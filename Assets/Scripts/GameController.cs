using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class GameController : MonoBehaviour
{
    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAd;
    public int deadCount;
    public bool rewarded = false;
    public PauseMenu pauseMenu;
    public CharaterHealth charaterHealth;

    private void Start()
    {
        deadCount = PlayerPrefs.GetInt("DeadCount", 1);
        RequestInterstitial();
        RequestRewarded();
    }

    public void PlayerDead()
    {
        deadCount++;
        PlayerPrefs.SetInt("DeadCount", deadCount);
        if (deadCount % 3 == 0)
        {
            if (this.interstitialAd.IsLoaded())
            {
                this.interstitialAd.Show();
            }
            else
            {
                RequestInterstitial();
            }
        }
    }

    public void WatchAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
        else
        {
            RequestRewarded();
        }
    }

    public void ReviveUsingCoins()
    {
        int coin = PlayerPrefs.GetInt("CoinCount");
        PlayerPrefs.SetInt("CoinCount", coin - 1000);
        pauseMenu.ResumeAfterReward();
    }

    // Start is called before the first frame update
    private void RequestInterstitial()
    {
        string adUnitId = "ca-app-pub-6541640901350895/6366965208";
        this.interstitialAd = new InterstitialAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.interstitialAd.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitialAd.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitialAd.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitialAd.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitialAd.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        AdRequest adRequest = new AdRequest.Builder().Build();
        this.interstitialAd.LoadAd(adRequest);

    }

    private void RequestRewarded()
    {
        string adUnitId = "ca-app-pub-6541640901350895/6989286891";
        this.rewardedAd = new RewardedAd(adUnitId);

        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;

        AdRequest adRequest = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(adRequest);
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
        rewarded = true;

        pauseMenu.ResumeAfterReward();


    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
}

