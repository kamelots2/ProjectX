using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject Boss = null;
    [SerializeField]
    GameObject PlayerM = null;
    [SerializeField]
    GameObject PlayerFM = null;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Boss.GetComponent<BossController>().Attack(false);
            PlayerM.GetComponent<HeroController>().Defense(true);
        }
    }
}
