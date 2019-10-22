using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerDataManager.Instance.Init();
    }
}
