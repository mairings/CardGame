using UnityEngine;
using TMPro;
using System;
namespace CardGame.UI
{
    public class RewardInfo : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _cash, _goldPile, _healthShot, _healthShotAdrenaline, _medkitEaster;
        public static Action OnSaveRewards;
      
        private void OnEnable()
        {
            OnSaveRewards += SaveRewards;
        }
        private void OnDisable()
        {
            OnSaveRewards -= SaveRewards;            
        }
        private void Start()
        {
            LoadRewards();
        }
        public void SetRewards(string name,string amount)
        {
            int amountInt = int.Parse(amount);
            switch (name)
            {
 
                case "UI_icon_cash":
                    IncreaseAmount(_cash, amountInt);
                    break;
                case "UI_icon_gold_pile":
                    IncreaseAmount(_goldPile, amountInt);
                    break;
                case "ui_icon_render_cons_healthshot_2":
                    IncreaseAmount(_healthShot, amountInt);
                    break;
                case "ui_icon_render_cons_healthshot_2_adrenaline":
                    IncreaseAmount(_healthShotAdrenaline, amountInt);
                    break;
                case "ui_icon_render_cons_medkit_easter":
                    IncreaseAmount(_medkitEaster, amountInt);
                    break;
            }
        }

        public void SaveRewards()
        {
            PlayerPrefs.SetInt("Cash", int.Parse(_cash.text));
            PlayerPrefs.SetInt("GoldPile", int.Parse(_goldPile.text));
            PlayerPrefs.SetInt("HealthShot", int.Parse(_healthShot.text));
            PlayerPrefs.SetInt("HSAdrenaline", int.Parse(_healthShotAdrenaline.text));
            PlayerPrefs.SetInt("MedkitEaster",  int.Parse(_medkitEaster.text));
        }
        public void LoadRewards()
        {
            IncreaseAmount(_cash, PlayerPrefs.GetInt("Cash"));
            IncreaseAmount(_goldPile, PlayerPrefs.GetInt("GoldPile"));
            IncreaseAmount(_healthShot, PlayerPrefs.GetInt("HealthShot"));
            IncreaseAmount(_healthShotAdrenaline, PlayerPrefs.GetInt("HSAdrenaline"));
            IncreaseAmount(_medkitEaster, PlayerPrefs.GetInt("MedkitEaster"));


        }

        void IncreaseAmount(TextMeshProUGUI tmp, int amount)
        {
            tmp.text = (int.Parse(tmp.text) + amount).ToString();
        }

    }
}
