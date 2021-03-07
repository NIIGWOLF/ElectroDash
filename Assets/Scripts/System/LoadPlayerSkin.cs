using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayerSkin : MonoBehaviour
{
    public bool eye = true;
    public bool body = true;
    public bool ps = true;
    void Awake()
    {
        Player player = gameObject.GetComponent<Player>();
        if (eye)
        {
            var temp = Resources.Load("Shops/Eyes/" + PlayerData.Instance.playerContent.Costume) as GameObject;
            player.Eye = Instantiate(temp, transform, false);
        }
        if (body)
        {
            var temp = Resources.Load("Shops/Costume/" + PlayerData.Instance.playerContent.Costume) as GameObject;
            gameObject.GetComponent<SpriteRenderer>().sprite = temp.GetComponent<SpriteRenderer>().sprite;
            foreach (Transform child in temp.transform)
            {
                Instantiate(child.gameObject, transform, false);
            }
        }
        if (ps)
        {
            var temp1 = Resources.Load("Shops/ParticleSystem/" + PlayerData.Instance.playerContent.Trails) as GameObject;
            Instantiate(temp1, transform, false);
            var temp2 = Resources.Load("Shops/Trails/" + PlayerData.Instance.playerContent.Trails) as GameObject;
            Instantiate(temp2, transform, false);
        }
    }
}
