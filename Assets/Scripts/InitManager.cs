using System.Collections.Generic;
using UnityEngine;
using System;

public class InitManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void UpdateUI(PlayerData data)
    {
        
    }
    void Start()
    {
        PlayerDataManager.Instance.Init();
        PlayerDataManager.Instance.updatestate += UpdateUI;
        //
    }
}
