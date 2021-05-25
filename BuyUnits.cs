using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyUnits : MonoBehaviour
{


    [SerializeField] private GameObject Canvas;
    [SerializeField] private int Price;
    [SerializeField] private string TypeUnit;
    public int Count;
    [SerializeField] private Sprite UnitImage;
    [SerializeField] private BuyUnitsManager BuyUnitsMang;

    private BuyUnits test;

    private void Start()
    {
        test = GetComponent<BuyUnits>();
        BuyUnitsMang = FindObjectOfType<BuyUnitsManager>();
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "MainCharacter")
            {
            
            Canvas.SetActive(true);
            BuyUnitsMang.typeUnit.text = TypeUnit;
            BuyUnitsMang.SetBuyUnitsScrypt(test);
            BuyUnitsMang.setWantToBuyNull();    
            BuyUnitsMang.UnitImagePreview.sprite = UnitImage;
            BuyUnitsMang.PricePerUnit = Price;
            BuyUnitsMang.CountUnits = Count;
            BuyUnitsMang.UpdateCanvas();

            }
        }
    

}
