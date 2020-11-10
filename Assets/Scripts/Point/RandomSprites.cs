using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprites : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();
    void Start()
    {
        if (GetComponent<SpriteRenderer>()){
            GetComponent<SpriteRenderer>().sprite=sprites[Random.Range(0,sprites.Count)];
        }
    }
}
