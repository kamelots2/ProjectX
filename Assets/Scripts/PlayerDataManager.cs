using UnityEngine;
using System.Collections;

public class PlayerData
{
   public PlayerData()
    {
        hp = 400;
        maxhp = 500;
        def = 10;
        atk = 15;
    }
    public int hp;
    public int def;
    public int atk;
    public int maxhp;
}

public class PlayerDataManager : Singleton<PlayerDataManager>
{
    PlayerData playerdata = new PlayerData();
    public delegate void UpdateState_DG(PlayerData param);
    public delegate void UpdateSkill_DG(PlayerData param);
    public delegate void UpdateItem_DG(PlayerData param);
    public UpdateState_DG updatestate;  
    public UpdateSkill_DG updateskill;
    public UpdateItem_DG updateitem;
    public PlayerData GetPlayerData()
    {
        return playerdata;
    }

    public void SetHP(int hp)
    {
        playerdata.hp -= hp;
        if (playerdata.hp < 0)
            playerdata.hp = 0;
        UpdateUI();
    }

    public void Init()
    {
        playerdata = new PlayerData();
    }

    void UpdateUI()
    {
        if(updatestate != null)
            updatestate(playerdata); 
    }

    void UpdateItem()
    {
        if (updateitem != null)
            updateitem(playerdata);
    }

    void UpdateSkill()
    {
        if (updateskill != null)
            updateskill(playerdata);
    }


}