using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    bool bIsDef;
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
        bIsDef = b;
        iTween.MoveTo(gameObject, iTween.Hash("x", 0.55f, "z", -8.99f, "time", 1f, "oncomplete", "MoveEnd",
            "oncompletetarget", gameObject));

    }

    void MoveEnd()
    {
        SetDefense(bIsDef);
    }

    void DefEnd()
    {
        iTween.MoveTo(gameObject, iTween.Hash("x", 0.301f, "z", -9.191f, "time", 1f, "delay", 3f));
        SetDefense(false);
    }

    void SetDefense(bool bIsDefense)
    {
        GetComponent<Animator>().SetBool("Def", bIsDefense);
    }
}
