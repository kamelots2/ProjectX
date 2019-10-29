using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject btnpf = null;
    [SerializeField]
    GameObject canvas = null;
    private List<GameObject> lButton = new List<GameObject>();
    private List<GameObject> lButtonPool = new List<GameObject>();
    private int BtnNum = 5;

    private void Start()
    {
        InitUIManager();

        SetButton(5);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitUIManager()
    {
        for(int i=0;i< BtnNum; i++)
        {
            GameObject prefab = (GameObject)Instantiate(btnpf);
            prefab.transform.SetParent(canvas.transform, false);
            prefab.SetActive(false);
            lButtonPool.Add(prefab);
        }
    }

    void GetButton(int n)
    {
        lButton.Clear();
        for (int i = BtnNum - 1; i >= 0; i--)
        {
            lButton.Add(lButtonPool[i]);
            n--;
            if (n == 0)
                break;         
        }
    }
    

    void SetButton(int n)
    {
        GetButton(n);
        //set button parameter
        for(int i=0;i<lButton.Count;i++)
        {
            lButton[i].GetComponent<ClickButton>().Init(0.2f, 1+i*0.5f);
            lButton[i].transform.position = new Vector3(300+i*100, 400, 0);
        }
    }
}
