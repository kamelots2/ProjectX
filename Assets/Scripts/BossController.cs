﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public delegate void BossSayEnd_DG();
    public delegate void BossAttackEvent_DG(int atk, bool bSkill);
    public delegate void BossAttackEnd_DG();
    public delegate void BossDead_DG();
    public delegate void UpdateBossiAV_DG(float value);
    public UpdateBossiAV_DG updatebossiAV;
    public BossSayEnd_DG bosssayend;
    public BossAttackEvent_DG bossattackevent;
    public BossAttackEnd_DG bossattackend;

    enum BossState
    {
        Plus,
        Minus,
    }
    struct BossInfo{
        public int iCurrentAV;
        public int iAV;
        public int iMaxAV;
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
    Animator anim;
    BossState state = BossState.Plus;
    List<List<string>> lBossText1 = new List<List<string>>();
    List<List<string>> lBossText2 = new List<List<string>>();
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
        bossinfo.iCurrentAV = 0;
        //UpdateBossiAV((float)bossinfo.iCurrentAV / bossinfo.iMaxAV);

        LoadDataManager.XLSX(lBossData[3][1], lBossText1);
        LoadDataManager.XLSX(lBossData[4][1], lBossText2);
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
            }
        }else
        {
            if (!bAttack)
            {
                bossinfo.iCurrentAV -= bossinfo.iAV;
            }
            else
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
        iTween.MoveTo(gameObject, iTween.Hash("x", -1.191f, "z", -8.237f, "time", 1f, "delay", 1f, "oncomplete", "AttackEnd",
            "oncompletetarget", gameObject));
    }

    void AttackEnd()
    {
        if (state == BossState.Minus && bossinfo.iCurrentAV == 0)
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
        sayTime = 3;
        bIsSay = true;
    }

    void AttackEvent()
    {
        if (bossattackevent != null)
            bossattackevent(bIsSkill ? bossinfo.atk:bossinfo.iAV, bIsSkill);
    }



    void UpdateBossiAV(float value)
    {
        if (updatebossiAV != null)
            updatebossiAV(value);
    }

    public bool IsDead()
    {
        return bIsDead;
    }
}
