using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BattleManager : MonoBehaviour
{
    [SerializeField] GameObject ExitButton;
    private Image BackgroundImg;

    //timers
    private bool win;
    [SerializeField] private GameObject[] Interface;
    [SerializeField] private GameObject BattleCanvas;


    [SerializeField] Unit[] HeroUnits;
    [SerializeField] Unit[] EnemyUnits;

    [SerializeField] Image[] PreviewUnitsImgHero;
    [SerializeField] Text[] PreviewUnitCountHero;
    [SerializeField] Text[] PreviewUnitsTypeHero;

    [SerializeField] Image[] PreviewUnitsImgEnemy;
    [SerializeField] Text[] PreviewUnitCountEnemy;
    [SerializeField] Text[] PreviewUnitsTypeEnemy;

    [SerializeField] ArmyManager HeroArmy;
    [SerializeField] EnemyManager EnemyArmy;

    [SerializeField] Image HeroPreview;
    [SerializeField] Text HeroUnitCount;
    [SerializeField] Text HeroUnitType;
    [SerializeField] Image EnemyPreview;
    [SerializeField] Text EnemyUnitType;
    [SerializeField] Text EnemyUnitCount;

    [SerializeField] Image PreviewEnemyHero;
    private bool TimerBattle = false;
    private float TimerBattleTic = 1f;
    private int RandomTemp;
    private int HeroIndex;
    private int EnemyIndex;
    int AliveHeroUnits = 0;
    int AliveEnemyUnits = 0;
    [SerializeField] private bool TimerBackground;
    private float TimerBackgroundTic = 0;

    


    private void Start()
    {
        BackgroundImg = GetComponent<Image>();
        BattleCanvas.SetActive(false);


    }

    void GetUnits()
    {
        for (int i = 0; i < 4; i++)
        {
            HeroUnits[i] = HeroArmy.Army[i];
            EnemyUnits[i] = EnemyArmy.Army[i];
            if (HeroUnits[i] != null && HeroUnits[i].countUnits > 0)
            {
               
               
                PreviewUnitsImgHero[i].sprite = HeroArmy.Army[i].PreviewUnit.sprite;
                PreviewUnitCountHero[i].text = HeroArmy.Army[i].countUnits.ToString();
               
            }
            else
            {
                PreviewUnitsImgHero[i].enabled = false;
                PreviewUnitCountHero[i].text = "";
            }
            if (EnemyUnits[i] != null && EnemyUnits[i].countUnits > 0)
            {
                
                PreviewUnitsImgEnemy[i].sprite = EnemyArmy.Army[i].PreviewUnit.sprite;
                PreviewUnitCountEnemy[i].text = EnemyArmy.Army[i].countUnits.ToString();
                
            }
            else
            {
                PreviewUnitsImgEnemy[i].enabled = false;
               PreviewUnitCountEnemy[i].text = "";
            }


        }

       

    }
    
    void BattleStart()
    {
         AliveHeroUnits=0;
         AliveEnemyUnits=0;
        for( int i = 0; i < 4 ; i++ )
        {
            if (HeroUnits[i] != null)
            {


                if (HeroUnits[i].countUnits != 0)
                {
                    AliveHeroUnits++;
                }
            }
        }
        for (int i = 0; i < 4; i++)
        {
            if (EnemyUnits[i] != null)
            {


                if (EnemyUnits[i].countUnits != 0)
                {
                    AliveEnemyUnits++;
                }
            }
        }
        
        if (AliveHeroUnits>0 && AliveHeroUnits >0 )
        {
            StartFight();
        }
    }

    void StartFight()
    {
        for(int i = 0;i<HeroUnits.Length;i++)
        {
            if(HeroUnits[i].countUnits!=0)
            {
                for(int j=0;j<EnemyUnits.Length;j++)
                {
                    if(EnemyUnits[j].countUnits !=0 )
                    {
                        
                        HeroIndex = i;
                        EnemyIndex = j;
                        
                        HeroPreview.sprite = HeroUnits[i].PreviewUnit.sprite;
                        HeroUnitCount.text = HeroUnits[i].countUnits.ToString();
                        HeroUnitType.text = HeroUnits[i].TypeUnit.ToString();

                        
                        EnemyUnitType.text = EnemyUnits[j].TypeUnit.ToString();
                        EnemyUnitCount.text = EnemyUnits[j].countUnits.ToString();
                        EnemyPreview.sprite = EnemyUnits[j].PreviewUnit.sprite;


                        TimerBattle = true;
                        TimerBattleTic = 1;
                        return;
                    }
                    
                }
            }
        }
        Debug.Log("FightEnd");
        TimerBattle = false;
    }

    public void PreBattleStart(EnemyManager getEnemyManager )
    {
        EnemyArmy = getEnemyManager;
        //EnemyUnitType = getUnitTypeText;
        TimerBackground = true;
    }
   private  void timers()
    {
        if(TimerBackground==true)
        {

            TimerBackgroundTic += 0.8f * Time.fixedDeltaTime;
            BackgroundImg.color = new Color(BackgroundImg.color.r, BackgroundImg.color.g, BackgroundImg.color.b, TimerBackgroundTic);
            if (TimerBackgroundTic >=1)
            {
                TimerBackground = false;
                BattleCanvas.SetActive(true);
                PreviewEnemyHero.sprite = EnemyArmy.GetComponent<SpriteRenderer>().sprite;
                disableInterface();
                GetUnits();
                BattleStart();


            }
        }
        if(TimerBattle==true)
        {
            TimerBattleTic -= 6 * Time.fixedDeltaTime;
            if(TimerBattleTic<=0)
            {
                TimerBattleTic = 1f;
                
                RandomTemp = Random.Range(0, 2);
               
                if(RandomTemp==0)
                {
                    HeroUnits[HeroIndex].countUnits--;
                    PreviewUnitCountHero[HeroIndex].text = HeroUnits[HeroIndex].countUnits.ToString();
                    HeroUnitCount.text = HeroUnits[HeroIndex].countUnits.ToString();
                }
                if(RandomTemp==1)
                {
                    EnemyUnits[EnemyIndex].countUnits--;
                    PreviewUnitCountEnemy[EnemyIndex].text = EnemyUnits[EnemyIndex].countUnits.ToString();
                    EnemyUnitCount.text = EnemyUnits[EnemyIndex].countUnits.ToString();
                }
                if(HeroUnits[HeroIndex].countUnits<=0 || EnemyUnits[EnemyIndex].countUnits <=0)
                {
                    if(HeroUnits[HeroIndex].countUnits <= 0)
                    {
                        AliveHeroUnits--;
                    }
                    if(EnemyUnits[EnemyIndex].countUnits<=0)
                    {
                        AliveEnemyUnits--;
                    }
                    if(AliveHeroUnits<=0)
                    {
                        Debug.Log("Lose");
                        win = false;
                        TimerBattle = false;
                        ExitButton.SetActive(true);
                        return;
                    }
                    if(AliveEnemyUnits<=0)
                    {
                        win = true;
                        Debug.Log("Win");
                        ExitButton.SetActive(true);
                       TimerBattle = false;
                        return;
                    }
                    if(AliveHeroUnits>0&&AliveEnemyUnits>0)
                    {
                        StartFight();
                    }
                    
                }
                
            }
        }
    }

    void disableInterface()
    {
        for(int i=0;i<Interface.Length;i++)
        {
            Interface[i].SetActive(false);
        }
    }
    void ActivateInterface()
    {
        for (int i = 0; i < Interface.Length; i++)
        {
            Interface[i].SetActive(true);
        }
    }
    public void ExitBattle()
    {
        
        if(win == true)
        {
            BackgroundImg.color = new Color(BackgroundImg.color.r, BackgroundImg.color.g, BackgroundImg.color.b, 0);
            ActivateInterface();
            EnemyArmy.Death();
            BattleCanvas.SetActive(false);
        }
        if(win == false)
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
    private void FixedUpdate()
    {
        timers();
       
    }
}
