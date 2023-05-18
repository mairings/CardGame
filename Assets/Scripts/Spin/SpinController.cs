using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CardGame.Cards;

namespace CardGame.Spins
{
    public class SpinController : Singleton<SpinController>
    {
        [Header("Datas")]
        public SpinUIData SpinUIData;
        public SpinDatas SpinDataBronze, SpinDataSilver, SpinDataGold, SpinDataCurrent;
        public WheelData _wheelData;

        [SerializeField] RewardCard _rewardCard;
        [Header("List")]
        public List<GameObject> ContentHolesList = new List<GameObject>();
        
        
        [Header("UI Elements")]
        [SerializeField] Image _spinImg, _indicatorImg, _buttonSpinImg, _panelBackground;

        [SerializeField] GameObject _giveUp;
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
        private void OnEnable()
        {
            GetSpinDatasLevel();
        }

        public void GetSpinDatasLevel()
        {
            int level = PlayerPrefsManager.Instance.CurrentLevel;
            int dataLevel = 0;
            //Silver
            if ((level+1)% _wheelData.SilverLevel==0 &&  (level+1) % _wheelData.GoldLevel !=0)
            {
                _giveUp.SetActive(true);
                SpinDataCurrent = SpinDataSilver;
                dataLevel = PlayerPrefsManager.Instance.SilverLevel;
                PlayerPrefsManager.Instance.SilverLevel++;
                SpinContentsGet(SpinUIData.SpinSprites[1], SpinUIData.IndicatorSprites[1], SpinUIData.ButtonSprites[1]);
            }
            //Gold
            else if ((level+1) % _wheelData.GoldLevel==0 )
            {
                _giveUp.SetActive(true);
                SpinDataCurrent = SpinDataGold;
                dataLevel = PlayerPrefsManager.Instance.GoldLevel;
                PlayerPrefsManager.Instance.GoldLevel++;
                SpinContentsGet(SpinUIData.SpinSprites[2], SpinUIData.IndicatorSprites[2], SpinUIData.ButtonSprites[2]);
            }
            //Bronze
            else
            {
                _giveUp.SetActive(false);
                SpinDataCurrent = SpinDataBronze;
                dataLevel = PlayerPrefsManager.Instance.BronzeLevel;
                PlayerPrefsManager.Instance.BronzeLevel++;
                SpinContentsGet(SpinUIData.SpinSprites[0], SpinUIData.IndicatorSprites[0], SpinUIData.ButtonSprites[0]);
            }

            for (int i = 0; i < ContentHolesList.Count; i++)
            {
                ContentHole contentHole = ContentHolesList[i].GetComponent<ContentHole>();

                contentHole.AmountTxt.text = "x" + SpinDataCurrent.MySpinValues[dataLevel].SlicesValue[i].ToString();
                contentHole.Reward.sprite = SpinUIData.RewardSprites[SpinDataCurrent.MySpinValues[dataLevel].RewardSpriteId[i]];
                contentHole.Amount = SpinDataCurrent.MySpinValues[dataLevel].SlicesValue[i];


            }
        }

        public void PanelBackgroundChange(int index)
        {
            _panelBackground.sprite = SpinUIData.PanelBackgrounds[index];
        }

    }

}
