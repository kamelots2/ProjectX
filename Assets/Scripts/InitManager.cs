using System.Collections.Generic;
using UnityEngine;
using System;

public class InitManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerDataManager.Instance.Init();
    }
}
