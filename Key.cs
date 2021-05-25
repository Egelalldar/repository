using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private MainCharacterController MainChar;

    private void Start()
    {
        MainChar = FindObjectOfType<MainCharacterController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.tag == "MainCharacter")
        {
            MainChar.KeyCount++;
            Destroy(gameObject);
        }
     }
}
