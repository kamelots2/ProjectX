using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject img = null;
    [SerializeField]
    GameObject perfectimg = null;
    private bool bIsVisible;
    private float perfecttime;
    private float showtime;
    [SerializeField]
    private float time = 2;
    private bool bIsPerfect;
    [SerializeField]
    private GameObject root = null;

    public bool IsVisible()
    {
        return bIsVisible;
    }

    public bool IsPerfect()
    {
        return bIsPerfect;
    }

    public void Init(float perfecttime, float showtime)
    {
        this.showtime = showtime;
        this.perfecttime = perfecttime;
        time = 2;
        bIsVisible = true;
        bIsPerfect = false;
        gameObject.SetActive(true);
        root.SetActive(false);
        perfectimg.transform.localScale = Vector3.one * (1f + perfecttime);
    }

    // Update is called once per frame
    void Update()
    {
        if (!bIsVisible)
        {
            return;
        }
        if(showtime > 0)
        {
            showtime -= Time.deltaTime;
            return;
        }
        if (!root.activeSelf)
            root.SetActive(true);
        time -= Time.deltaTime;
        img.transform.localScale = Vector3.one * time;
        if (time <= 1f - perfecttime)
            Press();
    }

    public void Press()
    {
        gameObject.SetActive(false);
        bIsVisible = false;
        if(time > 1f - perfecttime&&time < 1f+perfecttime)
        {
            bIsPerfect = true;
        }else
        {
            bIsPerfect = false;
        }
    }
}
