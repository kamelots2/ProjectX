using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public delegate void BossSayEnd_DG(int atk, bool bSkill);
    public delegate void UpdateBossHP_DG(float value);
    public BossSayEnd_DG bosssayend;
    public UpdateBossHP_DG updatebosshp;

    enum BossState
    {
        Plus,
        Minus,
    }
    struct BossInfo{
        public int hp;
        public int maxhp;
        public int atk;
    };
    private BossState state = BossState.Plus;
    private BossInfo bossinfo = new BossInfo();
    [SerializeField]
    GameObject gMoveToPosT = null;
    [SerializeField]
    GameObject gMoveToPosF = null;
    private float sayTime = -1;
    private bool bIsSay = false;
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
    }

    // Update is called once per frame
    void Update()
    {
        if(bIsSay)
        {
            sayTime -= Time.deltaTime;
            if (sayTime < 0)
            {
                SayEnd(bIsSay = false);
            }
        }
    }

    public void Attack(bool bAttack)
    {
        //update boss ui
        
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

    }

    void AttackEvent()
    {

    }

    public void Say()
    {
        sayTime = 2;
        bIsSay = true;
    }

    void SayEnd(bool skill)
    {
        if (bosssayend != null)
            bosssayend(skill?bossinfo.atk:bossinfo.hp, skill);
    }


    void BossDead()
    {
        
    }

    void UpdateBossHP(float value)
    {
        if (updatebosshp != null)
            updatebosshp(value);
    }
}
