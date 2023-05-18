using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="CardGame", menuName = "CardGame/SpinUIData")]
public class SpinUIData : ScriptableObject
{
    [Header("0:Spin 1:Indicator 2: Button")]
    public List<Sprite> SpinSprites = new List<Sprite>(); 
    public List<Sprite> RewardSprites = new List<Sprite>();
    public List<Sprite> IndicatorSprites = new List<Sprite>();
    public List<Sprite> ButtonSprites = new List<Sprite>();
    public List<Sprite> PanelBackgrounds = new List<Sprite>();

}
