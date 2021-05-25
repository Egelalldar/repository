using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public GoldManager GoldMang;
    private void Start()
    {
        GoldMang = FindObjectOfType<GoldManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "MainCharacter")
        {
            
            GoldMang.GoldCount+=Random.Range(10,30);
            Destroy(gameObject);


        }
    }
}
