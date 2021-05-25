using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour
{
    public bool MoveRight;
    public bool MoveLeft;
    public bool MoveUp;
    public bool MoveDown;
    public int KeyCount = 0;
    public int StepCounter = 10;
    void characterController()
    {   
        if (Input.GetKeyUp(KeyCode.W) && MoveUp == true && StepCounter > 0 )
        {
            StepCounter--;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.16f, gameObject.transform.position.z);
            
        }
        if (Input.GetKeyUp(KeyCode.D) && MoveRight == true && StepCounter > 0)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.16f, gameObject.transform.position.y, gameObject.transform.position.z);
            StepCounter--;
        }
        if (Input.GetKeyUp(KeyCode.A) && MoveLeft == true && StepCounter > 0)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.16f, gameObject.transform.position.y, gameObject.transform.position.z);
            StepCounter--;
        }
        if (Input.GetKeyUp(KeyCode.S) && MoveDown == true && StepCounter > 0)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.16f, gameObject.transform.position.z);
            StepCounter--;
        }
    }

    private void Update()
    {
        characterController();
    }

    private void FixedUpdate()
    {

    }
}
