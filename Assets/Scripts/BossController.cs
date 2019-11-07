using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    struct BossInfo{
        int hp;
        int maxhp;
        int atk;
    };
    private BossInfo bossinfo = new BossInfo();
    [SerializeField]
    GameObject gMoveToPosT = null;
    [SerializeField]
    GameObject gMoveToPosF = null;
    // Start is called before the first frame update
    void Start()
    {
        Init();
        //iTween.MoveTo(gameObject, iTween.Hash("x", 1f, "time", 1f));
        //iTween.MoveTo(gameObject, iTween.Hash("x", 2f, "time", 10f));
        
    }

    private void Init()
    {
        //init boss state
        List<List<int>> lBossData = new List<List<int>>();
        //LoadDataManager.XLSX("PlayerData.xlsx", lBossData);
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Attack(bool b)
    {
        if(b)
        {
            iTween.MoveTo(gameObject, iTween.Hash("x", 0.65f, "z", -9f, "time", 1f));

            iTween.MoveTo(gameObject, iTween.Hash("x", -1.191f, "z", -8.237f, "time", 1f, "delay", 1f));
        }else
        {
            iTween.MoveTo(gameObject, iTween.Hash("x", 0.25f, "z", -9f, "time", 1f));
            iTween.MoveTo(gameObject, iTween.Hash("x", -1.191f, "z", -8.237f, "time", 1f, "delay", 1f));
        }
    }
}
