using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDataInput : DataInput
{
    public override bool GetDataInput(out DateTime? result)
    {
        result = DateTime.Now;
        return true;
    }
    public void OnApplicationQuit()
    {      
        if(PlayerPrefs.GetInt(DailyReward.Current.RewardNum) == 0)
        {
            PlayerPrefs.SetString(DailyReward.Current.LastDate, JsonConvert.SerializeObject(DateTime.Now));
        }        
    }
}
