using UnityEngine;

public class Ad : MonoBehaviour
{
    public void ShowAddMap(){
        AdEvent.Instance.ShowAddMap(this);
    }

    public void ShowAddHelp(){
        AdEvent.Instance.ShowAddHelp(this);
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
                case AdEvent.Add.Coin:
                break;
            }
    }
}
