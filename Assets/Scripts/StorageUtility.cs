using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageUtility : MonoBehaviour
{
    public void ResetSaves()
    {
        PlayerPrefs.SetString(DailyReward.Current.FirstTime, "True");
    }
}
