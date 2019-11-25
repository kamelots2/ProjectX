using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject winUI;
    public GameObject lostUI;


    public void ShowWindow(int result)
    {
        gameObject.SetActive(true);

        if (result == 0)
        {
            winUI.SetActive(true);
            //win
        }
        else
        {
            lostUI.SetActive(true);
            //failed
        }
    }

    public void Back()
    {

        //SceneManager.LoadScene(0);
    }
}
