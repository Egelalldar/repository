using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnButton : MonoBehaviour
{
    [SerializeField] MainCharacterController charController;

    public void EndTurn()
    {
        charController.StepCounter = 10;
    }
}
