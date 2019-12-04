using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void ShowWindow(int result)
    {
        gameObject.SetActive(true);

        if (result == 0)
        {
            //winUI.SetActive(true);
            //win
            anim.Play("GameOver_Win");
        }
        else
        {
            //lostUI.SetActive(true);
            //failed
            anim.Play("GameOver_Failed");
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("map");
    }
}
