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
        uiManager.GetComponent<UIManager>().SetButton(5);
        time = 5;
        bIsAttack = true;
    }

    private void BossAttackEvent(int atk,bool isSkill)
    {
        if (uiManager.GetComponent<UIManager>().IsPerfect() == false)
        {
            PlayerFM.GetComponent<PrincessController>().ChangeState();
            PlayerHp= PlayerDataManager.Instance.GetPlayerData().hp-atk;
        }
        else
        {
            PlayerHp = PlayerDataManager.Instance.GetPlayerData().hp - atk+PlayerDataManager.Instance.GetPlayerData().def;
        }
        PlayerDataManager.Instance.SetHP(PlayerHp);

    }

    public void BossAttackEnd()
    {
        if (!Boss.GetComponent<BossController>().IsDead())
            Boss.GetComponent<BossController>().Say();
        else
        {
            //ReadData("");
            //init button

            //show button
            GameObject.Find("ButtonGroup").GetComponent<ButtonManager>().ShowButton();
        }
    }

    void ReadData(string filename)
    {
        LoadDataManager.XLSX(filename, lStrData);
    }


}
