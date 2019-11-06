using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Defense(bool b)
    {
        iTween.MoveTo(gameObject, iTween.Hash("x", 0.55f, "z", -8.99f, "time", 1f));
        GetComponent<Animator>().SetBool("Idle", false);
        GetComponent<Animator>().SetBool("Def", true);
        iTween.MoveTo(gameObject, iTween.Hash("x", 0.301f, "z", -9.191f, "time", 1f, "delay", 1f));
    }

    void DefEnd()
    {
        Debug.Log("Hello, world!");
        GetComponent<Animator>().SetBool("Idle", true);
        GetComponent<Animator>().SetBool("Def", false);
    }
}
