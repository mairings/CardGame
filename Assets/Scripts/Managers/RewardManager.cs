using UnityEngine;

namespace CardGame.Manager
{
    public class RewardManager : Singleton<RewardManager>
    {
        private (string, string,string)[] _rewardList = new (string, string,string)[] {
            ("UI_icon_cash", "CASH MONEY", "CashAmount"),
            ("UI_icon_gold_pile", "GOLD","GoldPileAmount"),
            ("ui_icon_render_cons_healthshot_2", "HEALTHSHOT","HealthShotAmount"),
            ("ui_icon_render_cons_healthshot_2_adrenaline", "HEALTHSHOT ADRENALINE", "HSAdrenalineAmount"),
            ("ui_icon_render_cons_medkit_easter", "MEDKIT EASTER","MedkitEasterAmount"),
            ("ui_icon_render_cons_grenade_m67", "BOMB", "bomb"),
            };

        public string GetRewardName(string rewardImageName)
        {
            string rewardName = null;
            foreach (var item in _rewardList)
            {
                if (item.Item1 == rewardImageName)
                {
                    rewardName = item.Item2;

                    break;
                }
            }
            
            return rewardName;
        }
        public int GetRewardIndex(string rewardImageName)
        {
            int rewardIndex = 0;

            for (int i = 0; i < _rewardList.Length; i++)
            {
                if (_rewardList[i].Item2 == rewardImageName)
                {
                    rewardIndex = i;
                }
            }
            return rewardIndex;
        }
    }
}
