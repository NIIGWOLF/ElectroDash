using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    Sequence seq;

    void Start()
    {
        Visual();
    }

    void Visual()
    {
        transform.Rotate(Vector3.zero, Space.World);
        transform.DORotate(new Vector3(0, 360, 0), 5, RotateMode.FastBeyond360).SetEase(Ease.Linear).OnComplete(Visual);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            StaticManager.levelManager.soundsManager.CoinSound.Play();
            gameObject.SetActive(false);
            StaticManager.levelManager.coinManager.countCoin++;
        }
    }
}
