using System;
using GoogleMobileAds.Api;
using UnityEngine;

public abstract class AdBase<T> : MonoBehaviour
{
    [SerializeField] protected string adId = "";

    protected virtual void Awake()
    {
        MobileAds.Initialize(initStatus => {

        });

        LoadAd();
    }

    public abstract void LoadAd();

    public abstract void AdLoadCallback(T ad, AdFailedToLoadEventArgs args);

    public abstract void HandleOnAdLoaded(object sender, EventArgs args);
    public abstract void HandleOnAdFailedToLoad(object sender, AdErrorEventArgs args);
    public abstract void HandleOnAdOpened(object sender, EventArgs args);
    public abstract void HandleOnAdClosed(object sender, EventArgs args);
}
