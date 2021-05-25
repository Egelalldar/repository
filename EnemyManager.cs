using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyManager : MonoBehaviour
{
    public Unit[] Army;
    public BattleManager BattleMng;
    private void Start()
    {
        
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "MainCharacter")
        {
            BattleMng.PreBattleStart(gameObject.GetComponent<EnemyManager>());
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
