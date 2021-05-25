using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArmyManager : MonoBehaviour
{
    public Unit[] Army;

    public void GetNewUnit(int count,string type,Sprite spriteImg)
    {
        int emptyslots = 0;
        for(int i=0;i<Army.Length;i++)
        {
            if( Army[i].TypeUnit == type)
            {
                Army[i].gameObject.SetActive(true);
                Army[i].countUnits += count;
                Army[i].TypeUnit = type;
                Army[i].PreviewUnit.sprite = spriteImg;
                break;
            }
            if(Army[i].countUnits <=0)
            {
                emptyslots++;
            }
            if(i == Army.Length-1 && emptyslots != 0)
            {
                for(int j = 0; j < Army.Length; j++)
                {
                    if(Army[j].countUnits <=0)
                    {
                        Army[j].gameObject.SetActive(true);
                        Army[j].countUnits += count;
                        Army[j].TypeUnit = type;
                        Army[j].ChangeSprite(spriteImg);
                        Army[j].PreviewUnit.sprite = spriteImg;
                        return;
                    }
                }
            }
            
        }
    }
    
        
}
