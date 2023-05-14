using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rewards", menuName = "RewardList")]
public class Rewards : ScriptableObject
{
    public List<Reward> rewards;
}
