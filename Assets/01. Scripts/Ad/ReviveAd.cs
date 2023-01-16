using System;
using GoogleMobileAds.Api;
using UnityEngine;

public class ReviveAd : RewardAdBase
{
    private FollowingCamera followingCamera = null;

    protected override void Awake()
    {
        base.Awake();

        followingCamera = DEFINE.MainCam.GetComponent<FollowingCamera>();
        Debug.Log(adId);
    }

    public override void HandleOnAdClosed(object sender, EventArgs args)
    {
        LoadAd();
    }

    public override void HandleOnAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        LoadAd();
    }

    public override void HandleOnAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        LoadAd();
    }

    public override void HandleOnAdLoaded(object sender, EventArgs args)
    {
        LoadAd();
    }

    public override void HandleOnAdOpened(object sender, EventArgs args)
    {
        LoadAd();
    }

    public override void HandleOnUserEarned(object sender, AdValueEventArgs args)
    {
        LoadAd();
    }

    public override void RewardedCallback(Reward reward)
    {
        gameObject.SetActive(false);
        followingCamera.Active(true);
    }
}
