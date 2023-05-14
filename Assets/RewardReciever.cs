using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;
using System;

public class RewardReciever : MonoBehaviour
{
    [Tooltip("Put elements in the same order like in reward list")]
    [SerializeField] private List<RecieveElement> recieveElements;

    private void Start()
    {
        DailyReward.Current.OnRecieveRewardAbility.AddListener(GetReward);
    }
    public void GetReward(Reward reward)
    {
        var rewardList = DailyReward.Current.GetRewardList();
        int index = rewardList.rewards.FindIndex(r => r == reward);
        recieveElements[index].SetEnableState();
        recieveElements[index].OnDisableStateSet.AddListener(() =>
            {               
            DailyReward.Current.CoinNum += reward.Num;
            recieveElements[index].OnDisableStateSet.RemoveAllListeners();
            PlayerPrefs.SetString(DailyReward.Current.LastDate, JsonConvert.SerializeObject(DateTime.Now));
            Debug.Log($"Recieved money " +
                    $"LastDate: " +
                    $"{JsonConvert.DeserializeObject<DateTime>(PlayerPrefs.GetString(DailyReward.Current.LastDate))}");
            });
    }
}
