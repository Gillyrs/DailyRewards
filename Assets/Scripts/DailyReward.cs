using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using Newtonsoft.Json;

public class DailyReward : MonoBehaviour
{
    public UnityEvent<Reward> OnRecieveRewardAbility;
    public int CoinNum;
    public static DailyReward Current;

    public readonly string FirstTime = "FirstTime";
    public readonly string RewardNum = "RewardNum";
    public readonly string LastDate = "LastDate";

    [SerializeField] private DataInput dataInput;
    [SerializeField] private Rewards rewards;
    
    
    private void Awake()
    {
        Current = this;
        Debug.Log(rewards.rewards.Count);
        if (PlayerPrefs.GetString(FirstTime) == "True")
        {
            InitSaves();
            Debug.Log($"First time, data initialized " +
                $"LastDate: {DateTime.Now}");
            PlayerPrefs.SetString(FirstTime, "False");
        }
        else if (PlayerPrefs.GetString(FirstTime) == "False")
        {
            Debug.Log($"Not FirstTime time " +
                $"LastDate: {JsonConvert.DeserializeObject<DateTime>(PlayerPrefs.GetString(LastDate))}");
        }
    }
    public Rewards GetRewardList() => rewards;
    public void InitSaves()
    {
        PlayerPrefs.SetInt(RewardNum, 0);
        PlayerPrefs.SetString(LastDate, JsonConvert.SerializeObject(DateTime.Now));
    }
    public void ProcessDataInput()
    {
        if (!dataInput.GetDataInput(out DateTime? input))
        {
            Debug.Log("Something wrong");
            return;
        }
        TimeSpan? dif = input - JsonConvert.DeserializeObject<DateTime>(PlayerPrefs.GetString(LastDate));
        Debug.Log($"Input: {input} \n" +
            $"LastDate: {JsonConvert.DeserializeObject<DateTime>(PlayerPrefs.GetString(LastDate))} \n" +
            $"Difference: {dif}");
        if (dif > new TimeSpan(1, 0, 0, 0)  && dif < new TimeSpan(2, 0, 0, 0))
        {
           OnRecieveRewardAbility.Invoke(RecieveRewardAbility());
            Debug.Log("Reward Ability recieved");
        }
        else if(dif > new TimeSpan(2, 0, 0, 0))
        {
            InitSaves();
            Debug.Log("Data reseted because of >2 days");
        }
    }
    public Reward RecieveRewardAbility()
    {
        int rewardNum = PlayerPrefs.GetInt(RewardNum);
        Reward reward = rewards.rewards[rewardNum];
        rewardNum++;
        PlayerPrefs.SetInt(RewardNum, rewardNum);
        return reward;
    }    
}
