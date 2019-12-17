using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BossSayEnd_DG();
public delegate void BossAttackEvent_DG(int atk, bool bSkill);
public delegate void BossAttackEnd_DG();
public delegate void BossDead_DG();
public delegate void UpdateBossiAV_DG(float value);
public delegate void QuestionEnd_DG();

public class BossController : MonoBehaviour
{
    public UpdateBossiAV_DG updatebossiAV;
    public BossSayEnd_DG bosssayend;
    public BossAttackEvent_DG bossattackevent;
    public BossAttackEnd_DG bossattackend;
    public QuestionEnd_DG questionend;
    [SerializeField]
    Canvas cBossMessage = null;

    enum BossState
    {
        Plus,
        Minus,
    }

    //enum BossSection
    //{
    //    First,
    //    Second,
    //}

    struct BossInfo{
        //angry value
        public int iCurrentAV;
        public int iAV;
        public int iMaxAV;
        public int atk;
        public int skillAtk;
    };

    BossInfo bossinfo = new BossInfo();
    float sayTime = -1;
    bool bIsSkill = false;
    bool bIsAttackEnd = false;
    int iSkillLv;

    Animator anim;
    BossState state = BossState.Plus;
    //BossSection section = BossSection.First;
    List<List<string>> lBossText1 = new List<List<string>>();
    List<List<string>> lBossText2 = new List<List<string>>();
    List<string> lQuestionText = new List<string>();
    int iTextIndex;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Init();
    }

    private void Init()
    {
        //init boss state
        List<List<string>> lBossData = new List<List<string>>();
        LoadDataManager.XLSX("Boss1Data.xlsx", lBossData);
        bossinfo.iMaxAV = int.Parse(lBossData[0][1]);
        bossinfo.iAV = int.Parse(lBossData[1][1]);
        bossinfo.atk = int.Parse(lBossData[2][1]);
        bossinfo.skillAtk = bossinfo.atk * 2;
        bossinfo.iCurrentAV = 0;
        //UpdateBossiAV((float)bossinfo.iCurrentAV / bossinfo.iMaxAV);
        iTextIndex = 0;
        iSkillLv = 1;
        LoadDataManager.XLSX(lBossData[3][1], lBossText1);
        LoadDataManager.XLSX(lBossData[4][1], lBossText2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack(bool bAttack)
    {
        //update boss ui and animation
        if(state == BossState.Plus)
        {
            if (!bAttack)
            {
                bossinfo.iCurrentAV += bossinfo.iAV;
            }
            else
            {
                bossinfo.iCurrentAV += (int)((float)bossinfo.iAV * 0.8f);
            }
            if (bossinfo.iCurrentAV >= bossinfo.iMaxAV)
            {
                bossinfo.iCurrentAV = bossinfo.iMaxAV;
                state = BossState.Minus;
                bIsSkill = true;
            }
        }else
        {
            if (!bAttack)
            {
                bossinfo.iCurrentAV -= bossinfo.iAV;
            }else
            {
                bossinfo.iCurrentAV -= (int)((float)bossinfo.iAV * 0.8f);
            }
            if (bossinfo.iCurrentAV <= 0)
            {
                bossinfo.iCurrentAV = 0;
            }
        }


        UpdateBossiAV((float)bossinfo.iCurrentAV / bossinfo.iMaxAV);
        if(bAttack)
        {
            iTween.MoveTo(gameObject, iTween.Hash("x", 0.65f, "z", -9f, "time", 1f, "oncomplete", "MoveEnd",
            "oncompletetarget", gameObject));
        }
        else
        {
            iTween.MoveTo(gameObject, iTween.Hash("x", 0.25f, "z", -9f, "time", 1f, "oncomplete", "MoveEnd",
            "oncompletetarget", gameObject));
        }
    }

    void MoveEnd()
    {
        anim.SetBool("Attack", true);
    }

    void AttackAnimEnd()
    {
        anim.SetBool("Attack", false);
        iTween.MoveTo(gameObject, iTween.Hash("x", -1.191f, "z", -8.237f, "time", 1f, "delay", 0.3f, "oncomplete", "AttackEnd",
            "oncompletetarget", gameObject));
    }

    void AttackEnd()
    {
        if (state == BossState.Minus && bossinfo.iCurrentAV == 0)
        {
            bIsAttackEnd = true;
            Say();
        }
        if(!bIsAttackEnd)
        {
            if (bossattackend != null)
                bossattackend();
        }     
    }

    void SayEnd()
    {
        if (bosssayend != null)
            bosssayend();
    }

    public void Say()
    {
        if (iTextIndex < lBossText1.Count)
        {
            sayTime = cBossMessage.GetComponent<BossMessageController>().ShowText(lBossText1[iTextIndex++][0]);
            StartCoroutine("SayOK"); 
        }
    }

    void AttackEvent()
    {
        if (bossattackevent != null)
            bossattackevent(bIsSkill ? bossinfo.atk:bossinfo.skillAtk*iSkillLv, bIsSkill);
        if (bIsSkill)
            bIsSkill = false;
    }



    void UpdateBossiAV(float value)
    {
        if (updatebossiAV != null)
            updatebossiAV(value);
    }

    public bool IsDead()
    {
        return bIsAttackEnd;
    }

    public List<string> GetButtonInfo()
    {
        return lBossText2[iTextIndex];
    }

    IEnumerator SayOK()
    {
        yield return new WaitForSeconds(sayTime);

        if (CheckSay())
        {
            SayEnd();
        }
        else
        {
            Say();
        }
    }

    bool CheckSay() //sayend : true
    {
        if (!bIsAttackEnd)
        {
            if (state == BossState.Plus)
            {
                return true;
            }
            else
            {
                if(int.Parse(lBossText1[iTextIndex][1]) < 0)
                {
                    return true;
                }else
                {
                    iSkillLv++;
                    return false;
                }
            }
        }
        else
        {
            if (iTextIndex >= lBossText1.Count)
            {
                return true;
            }
        }
        return false;
    }

    public void  ChangeState()
    {
        iTextIndex = 0;
        //section = BossSection.Second;
        LoadQuestion(-1);
    }

    public int LoadQuestion(int type)
    {
        lQuestionText.Clear();
        int result = 1;
        if (type == -1)
        {
            lQuestionText.Add(lBossText2[iTextIndex][0]);
        }else
        {
            iTextIndex = int.Parse(lBossText2[iTextIndex][type+2]);
            result = int.Parse(lBossText2[iTextIndex][1]);
            lQuestionText.Add(lBossText2[iTextIndex][0]);
        }

        ShowQuestion();
        return result;
    }

    public void ShowQuestion()
    {
        sayTime = cBossMessage.GetComponent<BossMessageController>().ShowText(lBossText2[iTextIndex][0]);
        lQuestionText.RemoveAt(0);
        if (iTextIndex < lBossText2.Count)
        {
            StartCoroutine("ShowQuestionOK");
        } 
    }

    IEnumerator ShowQuestionOK()
    {
        yield return new WaitForSeconds(sayTime);

        if (CheckQuestion())
        {
            ShowQuestionEnd();
        }
        else
        {
            ShowQuestion();
        }
    }

    bool CheckQuestion()
    {
        return lQuestionText.Count > 0 ? false : true;
    }

    public void ShowQuestionEnd()
    {
        if (questionend != null)
            questionend();
    }
}
