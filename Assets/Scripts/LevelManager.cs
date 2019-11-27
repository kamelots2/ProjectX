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
    GameObject UIManager=null;
    [SerializeField]
    GameObject ButtonGroup = null;
    [SerializeField]
    GameObject GameOverWindow = null;
    int PlayerHp;
    float time;
    bool bIsAttack = false;
    List<List<string>> lStrData = new List<List<string>>();

    void Start()
    {
        LanguageManager.Instance.InitLanguage();
       
        Boss.GetComponent<BossController>().bossattackevent += BossAttackEvent;
        Boss.GetComponent<BossController>().bossattackend += BossAttackEnd;
        Boss.GetComponent<BossController>().bosssayend += SayEnd;
        Boss.GetComponent<BossController>().questionend += ShowButton;
        Boss.GetComponent<BossController>().Say();

        PlayerHp = PlayerDataManager.Instance.GetPlayerData().hp;

        ButtonGroup.GetComponent<ButtonManager>().OnButtonClick += OnButtonClick;
    }

    // Update is called once per frame
    void Update()
    {
        if(bIsAttack)
        { 
            time -= Time.deltaTime;
            if(time < 0)
            {
                Boss.GetComponent<BossController>().Attack(!UIManager.GetComponent<UIManager>().IsPerfect());
                PlayerM.GetComponent<HeroController>().Defense(true);
                bIsAttack = false;
            }
        }
    }

    public void SayEnd()
    {
        if (!Boss.GetComponent<BossController>().IsDead())
        {
            int num = Random.Range(1, 5);
            UIManager.GetComponent<UIManager>().SetButton(num);
            time = 2+(int)((num-1)*0.5f);
            bIsAttack = true;
        }
        else
        {      
            Boss.GetComponent<BossController>().ChangeState();
        }
    }

    private void BossAttackEvent(int atk,bool isSkill)
    {
        PlayerFM.GetComponent<PrincessController>().ChangeState(UIManager.GetComponent<UIManager>().IsPerfect());
        PlayerDataManager.Instance.SetHP(!UIManager.GetComponent<UIManager>().IsPerfect()?atk:(int)(atk*0.8f));
    }

    public void BossAttackEnd()
    {
        if (PlayerHp>0)
        {
            Boss.GetComponent<BossController>().Say();
        }
      
    }

    void ReadData(string filename)
    {
        LoadDataManager.XLSX(filename, lStrData);
    }

    private void OnDestroy()
    {
        
    }

    void CheckGameOver(int result)
    {
        if (result <= 0)
        {
            //game over
            GameOverWindow.GetComponent<GameOver>().ShowWindow(result);

            //win
            if (result == 0)
            {

            }
            else
            {
                //failed

                PlayerDataManager.Instance.ResetHP(PlayerHp);
            }
        }
    }

    void OnButtonClick(int type)
    {
        CheckGameOver(Boss.GetComponent<BossController>().LoadQuestion(type));
    }

    void ShowButton()
    {
        //init button text
        ButtonGroup.GetComponent<ButtonManager>().SetButtonInfo(Boss.GetComponent<BossController>().GetButtonInfo());
        //show button
        ButtonGroup.GetComponent<ButtonManager>().ShowButton();
    }
}
