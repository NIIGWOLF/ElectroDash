using UnityEngine.Advertisements;
using UnityEngine;

public class AdEvent : Singleton<AdEvent>, IUnityAdsListener 
{
    public enum Add{ Map, Help, Coin, HelpPlay};
    private Add add;
    private Ad ad;
    
    public void OnUnityAdsDidError(string message)
    {
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished){
            print("Реклама досмотрена до конца");
            switch(add){
                case Add.Map:
                    ad.AddValue(Add.Map);
                break;
                case Add.Help:
                    ad.AddValue(Add.Help);
                break;
                case Add.Coin:
                    ad.AddValue(Add.Coin);
                break;
                case Add.HelpPlay:
                    ad.AddValue(Add.HelpPlay);
                break;
            }
            //реклама просмотрена до конца
        }else if(showResult == ShowResult.Failed){
            print("Реклама пропущена");
            //что-то пошло не так
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }

    public void OnUnityAdsReady(string placementId)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.AddListener(this);
        if (Advertisement.isSupported){
            Advertisement.Initialize("4092201",false);
        }
    }
    public void init(){

    }
    public void ShowAddMap(Ad ad){
        this.ad = ad;
        if (Advertisement.IsReady("Rewarded_Android")){
            Advertisement.Show("Rewarded_Android");
            add=Add.Map;
            print("Реклама запущена");
        }else
            print("Реклама не готова");
    }

    public void ShowAddHelp(Ad ad, bool isPlay){
        this.ad = ad;
        if (Advertisement.IsReady("Rewarded_Android")){
            Advertisement.Show("Rewarded_Android");
            if (isPlay) add=Add.HelpPlay;
            else add=Add.Help;
            print("Реклама запущена");
        }else
            print("Реклама не готова");
    }

    public void ShowAddCoin(Ad ad){
        this.ad = ad;
        if (Advertisement.IsReady("Rewarded_Android")){
            Advertisement.Show("Rewarded_Android");
            add=Add.Coin;
            print("Реклама запущена");
        }else
            print("Реклама не готова");
    }
}
