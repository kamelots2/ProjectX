using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject clickbtn = null;
    [SerializeField]
    GameObject choosebtn = null;
    [SerializeField]
    Slider  splayerhp = null;
    [SerializeField]
    Slider  sbosshp = null;
    private List<GameObject> lButton = new List<GameObject>();
    private List<GameObject> lButtonPool = new List<GameObject>();
    private int BtnNum = 5;

    private void Start()
    {
        InitUIManager();
        //SetButton(3);
        PlayerDataManager.Instance.updatestate += UpdateUIForPlayer;
        UpdateUIForPlayer(PlayerDataManager.Instance.GetPlayerData());
        sbosshp.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            //ShowChooseButton();
        }
    }

    void InitUIManager()
    {
        //init time 
        //choosebtn.SetActive(false);

        for (int i=0;i< BtnNum; i++)
        {
            GameObject prefab = (GameObject)Instantiate(clickbtn);
            prefab.transform.SetParent(gameObject.transform, false);
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
    

    void SetButton(int n)
    {
        GetButton(n);
        //set button parameter
        for(int i=0;i<lButton.Count;i++)
        {
            lButton[i].GetComponent<ClickButton>().Init(0.1f, 0+i*0.5f);
            lButton[i].transform.position = new Vector3(300+i*100, 400, 0);
        }
    }

    bool IsPerfect()
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

    void ShowChooseButton()
    {
        //choosebtn.SetActive(true);
        ((Animator)choosebtn.GetComponent<Animator>()).Play("New State");
    }

    void UpdateUIForPlayer(PlayerData data)
    {
        splayerhp.value = (float)data.hp / (float)data.maxhp;
    }
}
