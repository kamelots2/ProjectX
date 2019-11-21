using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject Boss = null;
    [SerializeField]
    GameObject PlayerM = null;
    [SerializeField]
    GameObject PlayerFM = null;
    [SerializeField]
    GameObject uiManager=null;
    int PlayerHp;
    float time;
    bool bIsAttack = false;
    List<List<string>> lStrData = new List<List<string>>();

    void Start()
    {
        Boss.GetComponent<BossController>().bossattackevent += BossAttackEvent;
        Boss.GetComponent<BossController>().bossattackend += BossAttackEnd;
        Boss.GetComponent<BossController>().bosssayend += SayEnd;
        Boss.GetComponent<BossController>().Say();

        PlayerHp = PlayerDataManager.Instance.GetPlayerData().hp;
    }

    // Update is called once per frame
    void Update()
    {
        if(bIsAttack)
        { 
            time -= Time.deltaTime;
            if(time < 0)
            {
                Boss.GetComponent<BossController>().Attack(false);
                PlayerM.GetComponent<HeroController>().Defense(true);
                bIsAttack = false;
            }
        }
    }

    public void SayEnd()
    {
        if (!Boss.GetComponent<BossController>().IsDead())
        {   
            uiManager.GetComponent<UIManager>().SetButton(5);
            time = 4;
            bIsAttack = true;
        }
        else
        {
            //ReadData("");
            //init button
            Boss.GetComponent<BossController>().ChangeState();
            Boss.GetComponent<BossController>().ShowQuastion();
            GameObject.Find("ButtonGroup").GetComponent<ButtonManager>().SetButtonInfo(Boss.GetComponent<BossController>().GetButtonInfo());
            //show button
            GameObject.Find("ButtonGroup").GetComponent<ButtonManager>().ShowButton();
        }
    }

    private void BossAttackEvent(int atk,bool isSkill)
    {
        //if (uiManager.GetComponent<UIManager>().IsPerfect() == false)
        //{
        //    PlayerFM.GetComponent<PrincessController>().ChangeState(uiManager.GetComponent<UIManager>().IsPerfect());
        //}
        //else
        //{
        //    PlayerHp = PlayerDataManager.Instance.GetPlayerData().hp - atk + PlayerDataManager.Instance.GetPlayerData().def;
        //}
        PlayerFM.GetComponent<PrincessController>().ChangeState(uiManager.GetComponent<UIManager>().IsPerfect());
        PlayerDataManager.Instance.SetHP(!uiManager.GetComponent<UIManager>().IsPerfect()?atk:(int)(atk*0.8f));

    }

    public void BossAttackEnd()
    { 
        Boss.GetComponent<BossController>().Say();
    }

    void ReadData(string filename)
    {
        LoadDataManager.XLSX(filename, lStrData);
    }

    private void OnDestroy()
    {
        
    }

    void GameOver()
    {
        //win


        //failed
        PlayerDataManager.Instance.ResetHP(PlayerHp);

        //loadMap
    }
}
