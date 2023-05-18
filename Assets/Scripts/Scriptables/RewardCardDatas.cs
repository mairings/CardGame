using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "RewardCardDatas", menuName = "CardGame/RewardCardDatas")]

public class RewardCardDatas : ScriptableObject
    {
    [Header("Card Rotation Animation Values")]
    public Vector3 CardRotValues;
     [Range(0.2f, 1.2f)] public float RotDuration;
     [Range(0.2f, 1.2f)] public float CardDisableDuration;

    
}