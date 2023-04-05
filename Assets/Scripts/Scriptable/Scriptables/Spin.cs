using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardGame", menuName = "CardGame/Spin")]
public class Spin : ScriptableObject
{
    public List<int> SlicesValue = new List<int>(8);
    public List<SliceReward> SlicesRewads = new List<SliceReward>(8);
    public enum SliceReward
    {
         Cash,
         GoldPile,
         RenderConsGrenadeElectric,
         RenderConsGrenadeM,
         RenderConsGrenadeSnowBall,
         RenderConsHealthShot,
         RenderConsHealthShotAdrenaline,
         RenderConsMedKitEaster,
         RenderTConsC,
         RenderTConsGrenadeEmp
    }
}
