using GoogleMobileAds.Api;
using UnityEngine;

public abstract class RewardAdBase : AdBase<RewardedInterstitialAd>
{
    private RewardedInterstitialAd rewardedAd;

    public override void LoadAd()
    {
        AdRequest req = new AdRequest.Builder().Build();
        RewardedInterstitialAd.LoadAd(adId, req, AdLoadCallback);
    }

    public override void AdLoadCallback(RewardedInterstitialAd ad, AdFailedToLoadEventArgs args)
    {
        if(args != null) { Debug.Log("There is some error loading ad"); return; }

        rewardedAd = ad;
        rewardedAd.OnAdFailedToPresentFullScreenContent += HandleOnAdFailedToShow;
        rewardedAd.OnAdDidPresentFullScreenContent += HandleOnAdLoaded;
        rewardedAd.OnAdDidDismissFullScreenContent += HandleOnAdClosed;
        rewardedAd.OnPaidEvent += HandleOnUserEarned;
    }

    public abstract void HandleOnUserEarned(object sender, AdValueEventArgs args);
    public abstract void HandleOnAdFailedToShow(object sender, AdErrorEventArgs args);
    public abstract void RewardedCallback(Reward reward);

    public void ShowAd()
    {
        if(rewardedAd == null)
            return;

        rewardedAd.Show(RewardedCallback);
    }
}
