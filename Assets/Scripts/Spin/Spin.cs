using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using CardGame.Cards;

namespace CardGame.Spin
{
    public class Spin : Singleton<Spin>
    {
        [Header("Datas")]
        public SpinUIData SpinUIData;
        public SpinDatas SpinData;
        SpinDatas _currentData;
        [SerializeField] RewardCard _rewardCard;
        
        [Header("List")]
        public List<GameObject> ContentHolesList = new List<GameObject>();
        
        
        [Header("UI Elements")]
        [SerializeField] Image _spinImg, _indicatorImg, _buttonSpinImg;


        private void Start()
        {
            GetSpinDatasLevel();
        }

        void SpinContentsGet(Sprite spinImg, Sprite indicatorImg, Sprite buttonSpinImg)
        {
            _spinImg.sprite = spinImg;
            _indicatorImg.sprite = indicatorImg;
            _buttonSpinImg.sprite = buttonSpinImg;
        }

        public void GetSpinDatasLevel()
        {
            int level = PlayerPrefs.GetInt("Level");
            print("MYLEvel"+ level);
            if ((level+1)% 4==0)
            {
                SpinContentsGet(SpinUIData.SpinSprites[1], SpinUIData.IndicatorSprites[1], SpinUIData.ButtonSprites[1]);
            }
            else if ((level+1) % 29==0)
            {
                SpinContentsGet(SpinUIData.SpinSprites[2], SpinUIData.IndicatorSprites[2], SpinUIData.ButtonSprites[2]);
            }
            else
            {
                SpinContentsGet(SpinUIData.SpinSprites[0], SpinUIData.IndicatorSprites[0], SpinUIData.ButtonSprites[0]);
            }


            for (int i = 0; i < ContentHolesList.Count; i++)
            {
                ContentHole contentHole = ContentHolesList[i].GetComponent<ContentHole>();

                    contentHole.Amount.text = "x" + SpinData.MySpinValues[level].SlicesValue[i].ToString();

                    switch (SpinData.MySpinValues[level].SlicesRewads[i])
                    {
                        case global::Spin.SliceReward.Cash:
                            contentHole.Reward.sprite = SpinUIData.RewardSprites[0];
                            break;
                        case global::Spin.SliceReward.GoldPile:
                            contentHole.Reward.sprite = SpinUIData.RewardSprites[1];
                            break;
                        case global::Spin.SliceReward.RenderConsGrenadeElectric:
                            contentHole.Reward.sprite = SpinUIData.RewardSprites[2];
                            break;
                        case global::Spin.SliceReward.RenderConsGrenadeM:
                            contentHole.Reward.sprite = SpinUIData.RewardSprites[3];
                            break;
                        case global::Spin.SliceReward.RenderConsGrenadeSnowBall:
                            contentHole.Reward.sprite = SpinUIData.RewardSprites[4];
                            break;
                        case global::Spin.SliceReward.RenderConsHealthShot:
                            contentHole.Reward.sprite = SpinUIData.RewardSprites[5];
                            break;
                        case global::Spin.SliceReward.RenderConsHealthShotAdrenaline:
                            contentHole.Reward.sprite = SpinUIData.RewardSprites[6];
                            break;
                        case global::Spin.SliceReward.RenderConsMedKitEaster:
                            contentHole.Reward.sprite = SpinUIData.RewardSprites[7];
                            break;
                        case global::Spin.SliceReward.RenderTConsC:
                            contentHole.Reward.sprite = SpinUIData.RewardSprites[8];
                            break;
                        case global::Spin.SliceReward.RenderTConsGrenadeEmp:
                            contentHole.Reward.sprite = SpinUIData.RewardSprites[9];
                            break;
                        default:
                            break;
                    
                }
            }
            
        }



    }
}
