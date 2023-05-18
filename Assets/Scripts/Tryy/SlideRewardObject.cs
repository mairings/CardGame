using UnityEngine;

public enum SlideReward
{
    None,
    Gold,
    Silver,
    Bronze
}

[CreateAssetMenu(fileName = "New Slide Reward", menuName = "Rewards/Slide")]
public class SlideRewardObject : ScriptableObject
{
    [SerializeField]
    private SlideReward rewardType;

    public SlideReward RewardType
    {
        get { return rewardType; }
        set { rewardType = value; }
    }
}