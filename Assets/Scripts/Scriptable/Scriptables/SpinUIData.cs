using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="CardGame", menuName = "CardGame/SpinUIData")]
public class SpinUIData : ScriptableObject
{
    public List<Sprite> SpinSprites = new List<Sprite>();
    public List<Sprite> IndicatorSprites = new List<Sprite>();
    public List<Sprite> ButtonSprites = new List<Sprite>();
}
