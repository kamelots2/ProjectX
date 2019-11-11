using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public delegate void BossSayEnd_DG();
    public delegate void BossAttackEvent_DG(int atk, bool bSkill);
    public delegate void BossAttackEnd_DG();
    public delegate void BossDead_DG();
    public delegate void UpdateBossHP_DG(float value);
    public UpdateBossHP_DG updatebosshp;
    public BossSayEnd_DG bosssayend;
    public BossAttackEvent_DG bossattackevent;
    public BossAttackEnd_DG bossattackend;

    enum BossState
    {
        Plus,
        Minus,
    }
    struct BossInfo{
        public int curHp;
        public int hp;
        public int maxhp;
        public int atk;
    };
    //private BossState state = BossState.Plus;
    private BossInfo bossinfo = new BossInfo();
    //[SerializeField]
    //GameObject gMoveToPosT = null;
    //[SerializeField]
    //GameObject gMoveToPosF = null;
    private float sayTime = -1;
    private bool bIsSay = false;
    private bool bIsSkill = false;
    private bool bIsDead = false;
    BossState state = BossState.Plus;
    // Start is called before the first frame update
    void Start()
    {
        Init();
      
    }

    private void Init()
    {
        //init boss state
        List<List<int>> lBossData = new List<List<int>>();
        //LoadDataManager.XLSX("PlayerData.xlsx", lBossData);
        bossinfo.maxhp = 100;
        bossinfo.hp = 50;
        bossinfo.atk = 30;
        bossinfo.curHp = 0;
        UpdateBossHP((float)bossinfo.curHp / bossinfo.maxhp);
    }

    // Update is called once per frame
    void Update()
    {
        if(bIsSay)
        {
            sayTime -= Time.deltaTime;
            if (sayTime < 0)
            {
                bIsSay = false;
                SayEnd();
            }
        }
    }

    public void Attack(bool bAttack)
    {
        //update boss ui
        if(state == BossState.Plus)
        {
            if (!bAttack)
            {
                bossinfo.curHp += bossinfo.hp;
            }
            else
            {
                bossinfo.curHp += (int)((float)bossinfo.hp * 0.8f);
            }
            if (bossinfo.curHp >= bossinfo.maxhp)
            {
                bossinfo.curHp = bossinfo.maxhp;
                state = BossState.Minus;
            }
        }else
        {
            if (!bAttack)
            {
                bossinfo.curHp -= bossinfo.hp;
            }
            else
            {
                bossinfo.curHp -= (int)((float)bossinfo.hp * 0.8f);
            }
            if (bossinfo.curHp <= 0)
            {
                bossinfo.curHp = 0;
                
            }
        }


        UpdateBossHP((float)bossinfo.curHp / bossinfo.maxhp);
        if(bAttack)
        {
            iTween.MoveTo(gameObject, iTween.Hash("x", 0.65f, "z", -9f, "time", 1f));
            //
            iTween.MoveTo(gameObject, iTween.Hash("x", -1.191f, "z", -8.237f, "time", 1f, "delay", 1f, "oncomplete", "AttackEnd",
            "oncompletetarget", gameObject));
        }
        else
        {
            iTween.MoveTo(gameObject, iTween.Hash("x", 0.25f, "z", -9f, "time", 1f));
            //
            iTween.MoveTo(gameObject, iTween.Hash("x", -1.191f, "z", -8.237f, "time", 1f, "delay", 1f, "oncomplete", "AttackEnd",
            "oncompletetarget", gameObject));
        }
    }

    void AttackEnd()
    {
        if (state == BossState.Minus && bossinfo.curHp == 0)
            bIsDead = true;
        if (bossattackend != null)
            bossattackend();  
    }

    void SayEnd()
    {
        if (bosssayend != null)
            bosssayend();
    }

    public void Say()
    {
        sayTime = 2;
        bIsSay = true;
    }

    void AttackEvent()
    {
        if (bossattackevent != null)
            bossattackevent(bIsSkill ? bossinfo.atk:bossinfo.hp, bIsSkill);
    }



    void UpdateBossHP(float value)
    {
        if (updatebosshp != null)
            updatebosshp(value);
    }

    public bool IsDead()
    {
        return bIsDead;
    }
}
