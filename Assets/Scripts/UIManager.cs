using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject gClickbtn = null;
    [SerializeField]
    Slider  sPlayerHP = null;
    [SerializeField]
    Slider  sBossHp = null;
    [SerializeField]
    GameObject gResult = null;
    private List<GameObject> lButton = new List<GameObject>();
    private List<GameObject> lButtonPool = new List<GameObject>();
    private int BtnNum = 5;
    [SerializeField]
    GameObject LeftTop = null;
    [SerializeField]
    GameObject RightDown = null;

    void Start()
    {
        InitUIManager();
        //SetButton(3);

        PlayerDataManager.Instance.updatestate += UpdateUIForPlayer;
        UpdateUIForPlayer(PlayerDataManager.Instance.GetPlayerData());
        sBossHp.value = 0;
        GameObject.Find("Boss").GetComponent<BossController>().updatebossiAV += UpdateUIForBoss;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitUIManager()
    {
        //init time 
        //choosebtn.SetActive(false);

        for (int i=0;i< BtnNum; i++)
        {
            GameObject prefab = (GameObject)Instantiate(gClickbtn);
            prefab.transform.SetParent(gameObject.transform, false);
            prefab.GetComponent<ClickButton>().backButtonResult += ShowResult;
            prefab.SetActive(false);
            lButtonPool.Add(prefab);
        }
    }

    void GetButton(int n)
    {
        lButton.Clear();
        if (n > BtnNum||n <= 0)
            n = BtnNum;
        for (int i = BtnNum - 1; n > 0; i--, n--)
        {
            lButton.Add(lButtonPool[i]);       
        }
    }
    

    public void SetButton(int n)
    {
        GetButton(n);
        //set button parameter
        for(int i=0;i<lButton.Count;i++)
        {

            float x = Random.Range(LeftTop.transform.position.x, RightDown.transform.position.x);
            float y = Random.Range(LeftTop.transform.position.y, RightDown.transform.position.y);

            lButton[i].GetComponent<ClickButton>().Init(0.15f, 0+i*0.5f);
            lButton[i].transform.position = new Vector3(x, y, 0);
        }
    }

    public bool IsPerfect()
    {
        for (int i = 0; i < lButton.Count; i++)
        {
            if(!lButton[i].GetComponent<ClickButton>().IsPerfect())
            {
                return false;
            }
        }
        return true;
    }

    void UpdateUIForPlayer(PlayerData data)
    {
        sPlayerHP.value = (float)data.hp / (float)data.maxhp;
    }

    void UpdateUIForBoss(float bossValue)
    {
        sBossHp.value = bossValue;
    }

    void OnDestroy()
    {
        PlayerDataManager.Instance.updatestate -= UpdateUIForPlayer;
    }

    void ShowResult(bool result)
    {
        gResult.GetComponentInChildren<Text>().text = result ? "Great" : "Bad";
        StopCoroutine("HideImg");
        gResult.SetActive(true);
        StartCoroutine("HideImg");
    }

    IEnumerator HideImg()
    {
        yield return new WaitForSeconds(0.7f);
        gResult.SetActive(false);
    }
}
