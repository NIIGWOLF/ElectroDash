using UnityEngine;

public class Ad : MonoBehaviour
{
    public void ShowAddMap(){
        AdEvent.Instance.ShowAddMap(this);
    }

    public void ShowAddHelp(bool isPlay){
        AdEvent.Instance.ShowAddHelp(this, isPlay);
    }

    public void ShowAddCoin(){
        AdEvent.Instance.ShowAddCoin(this);
    }

    public void AddValue(AdEvent.Add add){
        switch(add){
                case AdEvent.Add.Map:
                    GetComponent<BuyHint>().BuyMapHint();
                break;
                case AdEvent.Add.Help:
                    GetComponent<BuyHint>().BuySimpleHint();
                break;
                case AdEvent.Add.HelpPlay:
                    GetComponent<BuyHint>().BuySimpleHintPlay();
                break;
                case AdEvent.Add.Coin:
                GetComponent<BuyHint>().BuyCoin();
                break;
            }
    }
}
