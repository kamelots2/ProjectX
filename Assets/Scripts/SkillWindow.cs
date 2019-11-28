using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillWindow : MonoBehaviour, IWindow
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowWindow()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideWindow()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
