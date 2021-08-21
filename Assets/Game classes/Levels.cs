using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels 
{
    public int level_id;
    public string level_name;

    public Levels(int level_id, string level_name)
    {
        this.level_id = level_id;
        this.level_name = level_name;
    }
    public int getLevelId()
    {
        return level_id;
    }
    public string getLevelName()
    {
        return level_name;
    }
}
