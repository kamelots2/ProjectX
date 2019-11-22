using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void OnButtonPress_DG(int type);

public class ButtonManager : MonoBehaviour
{
    public OnButtonPress_DG OnButtonClick;
    Animator anim;
    [SerializeField]
    List<GameObject> lButton = null;
    public enum ButtonType
    {
        Btn1,
        Btn2,
        Btn3,
        Btn4,
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Press(int type)
    {
        //gameObject
        anim.Play("HideButton");
        if (OnButtonClick != null)
            OnButtonClick(type);
    }

    public void ShowButton()
    {
        anim.Play("ShowButton");
    }

    public void SetButtonInfo(List<string> lString)
    {
        int iButtonNum = int.Parse(lString[1]);
        foreach(GameObject obj in lButton)
        {
            obj.SetActive(false);
        }
        for(int i=0;i<iButtonNum;i++)
        {
            lButton[i].GetComponentInChildren<Text>().text =  LanguageManager.Instance.GetString(lString[2 +iButtonNum+ i]);
            lButton[i].SetActive(true);
        }
    }
}
