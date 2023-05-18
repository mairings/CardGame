using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "CardGame", menuName = "CardGame/RewardNameEnumAsset")]
public class EnumList : ScriptableObject
{
    public List<string> enumValues = new List<string>();


    public MyEnumNames[] MyEnumNamess;
    public enum MyEnumNames { };

 


}