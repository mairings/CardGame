using UnityEngine;
using TMPro;
using System;
using CardGame.Manager;
using System.Collections.Generic;

namespace CardGame.UI
{
    public class RewardInfo : MonoBehaviour
    {
        [SerializeField] List<TextMeshProUGUI> _rewardTexts;
        private void Start()
        {
            LoadRewards();
        }
        public void SetRewards(string name,int amount)
        {
            int getRewardIndex = RewardManager.Instance.GetRewardIndex(name);
             foreach (PlayerPrefsManager.KeyTypeReward keyType in System.Enum.GetValues(typeof(PlayerPrefsManager.KeyTypeReward)))
                {
                    if (getRewardIndex == (int)keyType)
                    {
                        string key = PlayerPrefsManager.KeyPrefix + keyType.ToString();
                        PlayerPrefs.SetInt(key, PlayerPrefs.GetInt(key) + amount);
                        GetTextAmount(_rewardTexts[getRewardIndex], PlayerPrefs.GetInt(key));
                    }
                }
        }

    
        public void LoadRewards()
        {
            
            foreach (PlayerPrefsManager.KeyTypeReward keyType in System.Enum.GetValues(typeof(PlayerPrefsManager.KeyTypeReward)))
            {
                string key = PlayerPrefsManager.KeyPrefix + keyType.ToString();
                _rewardTexts[(int)keyType].text = PlayerPrefs.GetInt(key).ToString();
            }

        }

        private void GetTextAmount(TextMeshProUGUI tmp, int amount)
        {
            tmp.text = amount.ToString();
        }

    }
}
