using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimCrl : MonoBehaviour
{
    void AttackEvent()
    {
        GameObject.Find("Boss").GetComponent<BossController>().AttackEvent();
    }

    void AttackEnd()
    {
        GameObject.Find("Boss").GetComponent<BossController>().AttackAnimEnd();
    }
}
