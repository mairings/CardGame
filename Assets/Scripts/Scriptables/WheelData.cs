using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardGame", menuName = "CardGame/WheelData")]
public class WheelData : ScriptableObject
{
    [Header("Wheel.cs")]
    public float RotationTime;
    public int MinimumSpinCount;
    public int MaxSpinCount;
    public float AngleIncreaseAmount;
    public int SilverLevel, GoldLevel;
    public int SpinCount;
    public float RotateAngleLimit;

    [Header("SpinContents.cs")]
    public float QuaterniotRotAngleAmount;

}
