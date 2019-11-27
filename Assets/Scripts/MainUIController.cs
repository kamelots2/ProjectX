using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUIController : MonoBehaviour
{
    [SerializeField]
    GameObject gPlayer = null;
    Slider sPlayerHP;
    Text sPlayerHPText;
    // Start is called before the first frame update
    void Start()
    {
        sPlayerHP = GetComponentInChildren<Slider>();
        sPlayerHPText = sPlayerHP.GetComponentInChildren<Text>();
        PlayerDataManager.Instance.updatestate += UpdateUIForPlayer;
        UpdateUIForPlayer(PlayerDataManager.Instance.GetPlayerData());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUIForPlayer(PlayerDataManager.PlayerData data)
    {
        sPlayerHP.value = (float)data.hp / (float)data.maxhp;
        sPlayerHPText.text = string.Format("{0}/{1}", data.hp, data.maxhp);
    }

    void OnDestroy()
    {
        PlayerDataManager.Instance.updatestate -= UpdateUIForPlayer;
    }

    public void OnBattle()
    {
        PlayerDataManager.Instance.postion = gPlayer.transform.position;
        SceneManager.LoadScene("Battle");
    }
}
