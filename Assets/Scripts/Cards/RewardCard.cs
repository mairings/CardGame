using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using DG.Tweening;
using CardGame.Manager;
using CardGame.Spins;
using CardGame.UI;


namespace CardGame.Cards
{
    public class RewardCard : Singleton<RewardCard>
    {
        [SerializeField] Image _rewardImage;
        [SerializeField] TextMeshProUGUI _amount;
        [SerializeField] TextMeshProUGUI _rewardName;
        [SerializeField] RewardInfo _rewardInfo;
        [SerializeField] RewardManager _rewardManager;
        [SerializeField] RewardCardDatas _data;


        [Header("Disabe Card Values")]
        [SerializeField] int _maxLevel;

        public void SetCardContent(Sprite rewardImage, int amount)
        {
            _rewardImage.sprite = rewardImage;
            _amount.text = "x"+ amount;
            _rewardName.text = _rewardManager.GetRewardName(rewardImage.name);
            _rewardInfo.SetRewards(_rewardManager.GetRewardName(rewardImage.name), amount);
        }

        public DeathStates DeathState;

        public enum DeathStates
        {
            BOMB,
        }
        private void OnEnable()
        {
            //Card Rotate Animation
            transform.DOLocalRotate(_data.CardRotValues,_data.RotDuration, RotateMode.FastBeyond360).OnComplete(() => {

                if (_rewardName.text == DeathState.ToString())
                {
                    UIManager.OnDeathPanel?.Invoke();
                }
                else
                {
                     StartCoroutine(Extensions.DelayedAction(this, _data.CardDisableDuration, () => {
                         DisableCard();
                    }));
                }
               
            });
        }

        private void DisableCard()
        {
            if (PlayerPrefsManager.Instance.CurrentLevel == _maxLevel)
            {
                UIManager.OnGameReset?.Invoke();
            }
            else
            {
                UIManager.OnWheelPanel?.Invoke();
            }
        }

    }
}
