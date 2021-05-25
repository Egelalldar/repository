using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Unit : MonoBehaviour
{
    public int countUnits;
    public string TypeUnit;
    public Image PreviewUnit;
    private Sprite tempSprite;
    [SerializeField] private Text countUnitsText;
    [SerializeField] private Text TypeUnitsText;
    


    private void Start()
    {

        
            PreviewUnit = GetComponent<Image>();
        
       // countUnits = 0;
      //  TypeUnit = "";
    }

     public void ChangeSprite(Sprite get)
    {
        if (PreviewUnit == null)
        {
            PreviewUnit = GetComponent<Image>();
        }
        PreviewUnit.sprite = get;
    }
    private void Update()
    {
        if(countUnitsText!=null)

        {
            countUnitsText.text = countUnits.ToString();
        }
        if(TypeUnitsText!=null)
        {
            TypeUnitsText.text = TypeUnit;
        }
       
        if(countUnits==0)
        {
            TypeUnit = "";
            countUnits = 0;
        }
    }
}
