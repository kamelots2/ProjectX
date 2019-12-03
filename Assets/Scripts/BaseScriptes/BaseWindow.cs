using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWindow : MonoBehaviour, IWindow
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void ShowWindow()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public virtual void HideWindow()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
