using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TurnCouner : MonoBehaviour
{
    public MainCharacterController charController;
    private Text turnTextCounter;

    private void Start()
    {
        turnTextCounter = GetComponent<Text>();
    }
    private void Update()
    {
        turnTextCounter.text = charController.StepCounter.ToString()+"/10";
    }
}
