using System;
using GoogleMobileAds.Api;
using UnityEngine;

public class ReviveAd : RewardAdBase
{
    private FollowingCamera followingCamera = null;
    private BallController ball = null;
    private InfinityModeManager manager = null;

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
        ball.transform.position = ball.LastRotaterPos;
        ball.LastRotator = null;
        ball.gameObject.SetActive(true);

        Vector3 camPos = followingCamera.transform.position;
        camPos.y = ball.transform.position.y<=0 ? 0 : ball.transform.position.y;
        followingCamera.transform.position = camPos;
        followingCamera.Active(true);

        Transform removeDetector = followingCamera.transform.Find("Confiner/Bottom");
        Debug.Log(removeDetector);
        manager = FindObjectOfType<InfinityModeManager>();
        foreach(Gimmick gimmick in manager.gimmicks){
            if(gimmick.transform.position.y>removeDetector.position.y){
                gimmick.gameObject.SetActive(true);
                gimmick.transform.SetParent(null);
            }
        }
        
        gameObject.SetActive(false);
        
    }
}
