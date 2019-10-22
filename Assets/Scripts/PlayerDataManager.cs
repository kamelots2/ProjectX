using UnityEngine;
using System.Collections;

public class PlayerData
{
   public PlayerData()
    {
        hp = 100;
        def = 100;
    }
    public int hp;
    public int def;
}
public class PlayerDataManager : Singleton<PlayerDataManager>
{
    PlayerData playerdata;
    public delegate void UpdateState_DG(PlayerData param);
    public delegate void UpdateSkill_DG(PlayerData param);
    public delegate void UpdateItem_DG(PlayerData param);
    public UpdateState_DG updatestate;  
    public UpdateSkill_DG updateskill;
    public UpdateItem_DG updateitem;
    PlayerData GetPlayerData()
    {
        return playerdata;
    }

    void SetHP(int hp)
    {
        playerdata.hp = hp;
        UpdateUI();
    }

    public void Init()
    {
        playerdata = new PlayerData();
        SetHP(10);
    }

    void UpdateUI()
    {
        updatestate(playerdata); 
    }

    void UpdateItem()
    {
        updateitem(playerdata);
    }

    void UpdateSkill()
    {
        updateskill(playerdata);
    }


}