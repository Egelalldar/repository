using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyUnitsManager : MonoBehaviour
{
    public Text typeUnit;
    [SerializeField] private Text PriceText;
    [SerializeField] private Text TotalCountText;
    [SerializeField] private Text WantBuyCount;
    [SerializeField] private Text FinalPriceText;
    public Image UnitImagePreview;
    [SerializeField] private GameObject BuyUnitsCanvas;
    [SerializeField]  private GoldManager GoldMng;
    [SerializeField] private InputField WantToBuyInputField;
   
    private BuyUnits test;
    private ArmyManager ArmyMang;
    public int PricePerUnit;
    public int CountUnits;

    private void Start()
    {
        ArmyMang = FindObjectOfType<ArmyManager>();
        BuyUnitsCanvas.SetActive(false);
    }
    public void setWantToBuyNull()
    {
       WantToBuyInputField.text = "";
       
    }
    public void SetBuyUnitsScrypt(BuyUnits get)
    {
        test = get;
    }
    public void UpdateCanvas()
    {
       
        
        PriceText.text = "Цена: " + PricePerUnit.ToString();
        TotalCountText.text = CountUnits.ToString();
    }
    public void BuyUnits()
    {

        if(GoldMng.GoldCount >= PricePerUnit * int.Parse(WantBuyCount.text.ToString()) && int.Parse(WantBuyCount.text.ToString()) <= int.Parse(TotalCountText.text.ToString()) ) 
        {
            test.Count = int.Parse(TotalCountText.text.ToString()) - int.Parse(WantBuyCount.text.ToString());
            TotalCountText.text = (int.Parse(TotalCountText.text.ToString()) - int.Parse(WantBuyCount.text.ToString())). ToString();
           
            GoldMng.GoldCount -= PricePerUnit * int.Parse(WantBuyCount.text.ToString());
            Debug.Log(UnitImagePreview.sprite);
            ArmyMang.GetNewUnit( int.Parse(WantBuyCount.text.ToString()), typeUnit.text.ToString() ,UnitImagePreview.sprite);
        }
    }
    public void ExitCanvas()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
       if(WantBuyCount.text == null || WantBuyCount.text == "")
        {
            FinalPriceText.text = "Итого: 0";
        }
       else
        {
            FinalPriceText.text = "Итого: " + (PricePerUnit * int.Parse(WantBuyCount.text.ToString())).ToString();
        }
       
         
       
      
    }
}
