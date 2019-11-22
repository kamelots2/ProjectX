using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void ShowWindow(int result)
    {
        gameObject.SetActive(true);

        if (result == 0)
        {
            //win
        }
        else
        {
            //failed
        }
    }

    public void Back()
    {

    }
}
