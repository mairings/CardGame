using UnityEngine;

namespace CardGame.Manager
{
    public class RewardManager : MonoBehaviour
    {
        private (string, string)[] _rewardList = new (string, string)[] {
            ("UI_icon_cash", "CASH MONEY"),
            ("UI_icon_gold_pile", "GOLD"),
            ("ui_icon_render_cons_grenade_m67", "BOMB"),
            ("ui_icon_render_cons_healthshot_2", "HEALTHSHOT"),
            ("ui_icon_render_cons_healthshot_2_adrenaline", "HEALTHSHOT ADRENALINE"),
            ("ui_icon_render_cons_medkit_easter", "MEDKIT EASTER")
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
    }
}
