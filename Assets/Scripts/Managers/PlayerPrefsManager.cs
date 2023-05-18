using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : Singleton<PlayerPrefsManager>
{
    public const string KeyPrefix = "CardGame_";

    public enum KeyTypeLevel
    {
        CurrentLevel,
        BronzeLevel,
        SilverLevel,
        GoldLevel

    }
    public enum KeyTypeReward
    {
        CashAmount,
        GoldPileAmount,
        HealthShotAmount,
        HSAdrenalineAmount,
        MedkitEasterAmount
    }
    private readonly string CurrentLevelKey = KeyPrefix + KeyTypeLevel.CurrentLevel.ToString();
    private readonly string BronzeLevelKey = KeyPrefix + KeyTypeLevel.BronzeLevel.ToString();
    private  readonly string SilverLevelKey = KeyPrefix + KeyTypeLevel.SilverLevel.ToString();
    private  readonly string GoldLevelKey = KeyPrefix + KeyTypeLevel.GoldLevel.ToString();
    private  readonly string CashAmountKey = KeyPrefix + KeyTypeReward.CashAmount.ToString();
    private  readonly string GoldPileAmountKey = KeyPrefix + KeyTypeReward.GoldPileAmount.ToString();
    private  readonly string HealthShotKey = KeyPrefix + KeyTypeReward.HealthShotAmount.ToString();
    private  readonly string HSAdrenalineKey = KeyPrefix + KeyTypeReward.HSAdrenalineAmount.ToString();
    private  readonly string MedkitEasterKey = KeyPrefix + KeyTypeReward.MedkitEasterAmount.ToString();


    public int CurrentLevel
    {
        get { return PlayerPrefs.GetInt(CurrentLevelKey); }
        set { PlayerPrefs.SetInt(CurrentLevelKey, value); }
    }

    public int BronzeLevel
    {
        get { return PlayerPrefs.GetInt(BronzeLevelKey); }
        set { PlayerPrefs.SetInt(BronzeLevelKey, value); }
    }
    public int SilverLevel
    {
        get { return PlayerPrefs.GetInt(SilverLevelKey); }
        set { PlayerPrefs.SetInt(SilverLevelKey, value); }
    }
    public int GoldLevel
    {
        get { return PlayerPrefs.GetInt(GoldLevelKey); }
        set { PlayerPrefs.SetInt(GoldLevelKey, value); }
    }
    public int CashAmount
    {
        get { return PlayerPrefs.GetInt(CashAmountKey); }
        set { PlayerPrefs.SetInt(CashAmountKey, value); }
    }
    public int GoldPileAmount
    {
        get { return PlayerPrefs.GetInt(GoldPileAmountKey); }
        set { PlayerPrefs.SetInt(GoldPileAmountKey, value); }
    }
    public int HealthShotAmount
    {
        get { return PlayerPrefs.GetInt(HealthShotKey); }
        set { PlayerPrefs.SetInt(HealthShotKey, value); }
    }
    public int HSAdrenalineAmount
    {
        get { return PlayerPrefs.GetInt(HSAdrenalineKey); }
        set { PlayerPrefs.SetInt(HSAdrenalineKey, value); }
    }
    public int MedkitEasterAmount
    {
        get { return PlayerPrefs.GetInt(MedkitEasterKey); }
        set { PlayerPrefs.SetInt(MedkitEasterKey, value); }
    }
    public void ResetAllKeys()
    {
        foreach (KeyTypeLevel keyType in System.Enum.GetValues(typeof(KeyTypeLevel)))
        {
            string key = KeyPrefix + keyType.ToString();
            PlayerPrefs.DeleteKey(key);
        }
        foreach (KeyTypeReward keyType in System.Enum.GetValues(typeof(KeyTypeReward)))
        {
            string key = KeyPrefix + keyType.ToString();
            PlayerPrefs.DeleteKey(key);
        }
    }
    public void WithDrawKeys()
    {
        foreach (KeyTypeLevel keyType in System.Enum.GetValues(typeof(KeyTypeLevel)))
        {
            string key = KeyPrefix + keyType.ToString();
            PlayerPrefs.DeleteKey(key);
        }
    }
}
