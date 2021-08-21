using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons 
{
    public int playerid;
    public string weapon_name; // MUST HAVE AN UPDATE FUNCTION TO UPDATE DB

    public Weapons(int playerid, string weapon_name)
    {
        this.playerid = playerid;
        this.weapon_name = weapon_name;
    }
    public string getWeaponName()
    {
        return weapon_name;
    }
    public void setWeaponName(string weaponName)
    {
        this.weapon_name = weaponName;
        // update function must called to update DB
    }
}
