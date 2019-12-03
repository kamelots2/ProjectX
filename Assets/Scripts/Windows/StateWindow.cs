using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateWindow : BaseWindow
{
    [SerializeField]
    Text hpText = null;
    [SerializeField]
    Text defText = null;
    // Start is called before the first frame update

    void Start()
    {
        PlayerDataManager.Instance.updatestate += UIUpdate;
    }

    public override void ShowWindow()
    {
        base.ShowWindow();
        UIUpdate(PlayerDataManager.Instance.GetPlayerData());
    }

    public override void HideWindow()
    {
        base.HideWindow();
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
