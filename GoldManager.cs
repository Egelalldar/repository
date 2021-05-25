using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GoldManager : MonoBehaviour
{
    public int GoldCount = 0;
    private Text goldText;
    private void Start()
    {
        goldText = GetComponent<Text>();
    }
    private void Update()
    {
        goldText.text = GoldCount.ToString();
    }
}
