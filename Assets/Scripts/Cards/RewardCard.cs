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

        public void SetCardContent(Sprite rewardImage, string amount)
        {
            _rewardImage.sprite = rewardImage;
            _amount.text = "x"+amount;
            _rewardName.text = _rewardManager.GetRewardName(rewardImage.name);
            _rewardInfo.SetRewards(rewardImage.name, amount);
        }

        private void OnEnable()
        {
            //Card Rotate Animation
            transform.DOLocalRotate(new Vector3(0, 360, 0), 0.4f, RotateMode.FastBeyond360).OnComplete(() => {
                if (_rewardImage.sprite.name== "ui_icon_render_cons_grenade_m67")
                {
                    UIManager.OnDeathPanel?.Invoke();
                }
                else
                {
                    Invoke("DisableCard", 0.4f);
                }
               
            });
        }

        void DisableCard()
        {
            if (PlayerPrefs.GetInt("Level") == 90)
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
