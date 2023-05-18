using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Spin
{
    public List<int> SlicesValue;
    public List<SliceReward> SlicesRewads;


    [Header("Sprites ids( Cash = 0 / GoldPile = 1 / Granade = 3 / Healtshot = 5 / Adrenaline = 6 / MedKit = 7)")]
    public List<int> RewardSpriteId;
    public Spin(List<int> slicesValue, List<SliceReward> slicesRewads, List<int> rewardSpriteId)
    {
        this.SlicesValue = slicesValue;
        this.SlicesRewads = slicesRewads;
        this.RewardSpriteId = rewardSpriteId;
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
    public Spin[] MySpinValues = new Spin[30];
    public EnumList MyEnumList;


}
