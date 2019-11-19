using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    Animator anim;
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
        //gameObject.p
        anim.Play("HideButton");
    }

    public void ShowButton()
    {
        anim.Play("ShowButton");
    }
}
