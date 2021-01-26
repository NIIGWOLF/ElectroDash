using UnityEngine;

public class StartDeathPS : MonoBehaviour
{
    public GameObject PSCreate;
    public int orderLayer=0;
    bool exit = false;
    void OnEnable()
    {
        Sprite sp = gameObject.GetComponent<SpriteRenderer>().sprite;
        GameObject gops=Instantiate(PSCreate,transform.position,Quaternion.Euler(transform.eulerAngles));
        gops.GetComponent<ParentPS>().parent=gameObject;
        var ps = gops.GetComponent<ParticleSystem>();
        ps.GetComponent<ParticleSystemRenderer>().sortingOrder=orderLayer;
        var shps = ps.shape;
        shps.sprite=sp;
    }

    void OnDestroy(){
        if (!exit){
        Sprite sp = gameObject.GetComponent<SpriteRenderer>().sprite;
        GameObject gops=Instantiate(PSCreate,transform.position,Quaternion.Euler(transform.eulerAngles));
        gops.GetComponent<ParentPS>().parent=gameObject;
        var ps = gops.GetComponent<ParticleSystem>();
        ps.GetComponent<ParticleSystemRenderer>().sortingOrder=orderLayer;
        var shps = ps.shape;
        shps.sprite=sp;
        }
    }

    void OnApplicationQuit(){
        exit=true;
    }
}
