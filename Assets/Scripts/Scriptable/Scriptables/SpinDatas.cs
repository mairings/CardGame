using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Spin
{
    public List<int> SlicesValue;
    public List<SliceReward> SlicesRewads;

    public Spin(List<int> slicesValue, List<SliceReward> slicesRewads)
    {
        this.SlicesValue = slicesValue;
        this.SlicesRewads = slicesRewads;
    }
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

[CreateAssetMenu(fileName = "CardGame", menuName = "CardGame/Spin")]
public class SpinDatas : ScriptableObject
{
    public Spin[] mySpinValues = new Spin[30];
}
