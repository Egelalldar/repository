using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCollider : MonoBehaviour
{

    public MainCharacterController CharController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "impassableObj")
        {
           
            switch (gameObject.name)
            {
                case "Up":
                    CharController.MoveUp = false;
                    break;
                case "Down":
                    CharController.MoveDown = false;
                    break;
                case "Left":
                    CharController.MoveLeft = false;
                    break;
                case "Right":
                    CharController.MoveRight = false;
                    break;
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "impassableObj")
        {

            switch (gameObject.name)
            {
                case "Up":
                    CharController.MoveUp = true;
                    break;
                case "Down":
                    CharController.MoveDown = true;
                    break;
                case "Left":
                    CharController.MoveLeft = true;
                    break;
                case "Right":
                    CharController.MoveRight = true;
                    break;
            }

        }
    }
}
