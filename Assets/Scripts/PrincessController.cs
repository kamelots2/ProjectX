using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public  void ChangeState(bool b)
   {
        if(b)
        {
            SayInfo();
        }else
        {

        }
   }

   void SayInfo()
   {

   }

   void AnimEndEvent()
   {
        //GetComponent<Animator>().SetBool("Idle", true);

   }
}
