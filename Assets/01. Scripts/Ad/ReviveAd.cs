using System;
using GoogleMobileAds.Api;
using UnityEngine;

public class ReviveAd : RewardAdBase
{
    private FollowingCamera followingCamera = null;
    private BallController ball = null;

    protected override void Awake()
    {
        base.Awake();

        followingCamera = DEFINE.MainCam.GetComponent<FollowingCamera>();
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
        ball = DEFINE.Ball;
        gameObject.SetActive(false);
        followingCamera.Active(true);
        ball.transform.position = ball.LastRotaterPos;
        ball.LastRotator = null;
        ball.gameObject.SetActive(true);
    }
}
