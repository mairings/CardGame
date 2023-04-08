using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using DG.Tweening;

namespace CardGame.Cards
{
    public class RewardCard : Singleton<RewardCard>
    {
        [SerializeField] Image _rewardImage;
        [SerializeField] TextMeshProUGUI _amount;
        
        public void SetCardContent(Sprite rewardImage, string amount)
        {
            _rewardImage.sprite = rewardImage;
            _amount.text = amount;
        }

        private void OnEnable()
        {
            transform.DOLocalRotate(new Vector3(0, 360, 0), 0.4f,RotateMode.FastBeyond360);
        }

    }
}
