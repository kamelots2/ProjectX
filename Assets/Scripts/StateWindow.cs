using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateWindow : MonoBehaviour, IWindow
{
    [SerializeField]
    Text hpText;
    [SerializeField]
    Text defText;
    // Start is called before the first frame update

    void Start()
    {
        PlayerDataManager.Instance.updatestate += UIUpdate;
    }

    public void ShowWindow()
    {
        gameObject.SetActive(true);
        UIUpdate(PlayerDataManager.Instance.GetPlayerData());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HideWindow()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    void UIUpdate(PlayerDataManager.PlayerData param)
    {
        hpText.text = string.Format("{0}", param.maxhp);
        defText.text = string.Format("{0}", param.def);
    }

    private void OnDestroy()
    {
        PlayerDataManager.Instance.updatestate -= UIUpdate;
    }
}
