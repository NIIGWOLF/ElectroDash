using UnityEngine;
using UnityEngine.Advertisements;

public class Ad : MonoBehaviour, IUnityAdsListener
{
    public void OnUnityAdsDidError(string message)
    {
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished){
            print("Реклама досмотрена до конца");
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
            Advertisement.Initialize("4092201",true);
        }
    }

    public void ShowAd(){
        if (Advertisement.IsReady("Rewarded_Android")){
            Advertisement.Show("Rewarded_Android");
            print("Реклама запущена");
        }else
            print("Реклама не готова");
        
    }
}
