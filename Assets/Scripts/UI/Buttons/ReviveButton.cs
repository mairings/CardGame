using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using CardGame.Manager;

namespace CardGame.UI
{
    public class ReviveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
            [SerializeField] TextMeshProUGUI _money;
            [SerializeField] TextMeshProUGUI _reviveAmountTmp;
            [SerializeField] int _reviveAmount;

        private void Start()
        {
            _reviveAmountTmp.text = _reviveAmount + "$ REVIVE";
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            int money = int.Parse(_money.text);
            if (money >= _reviveAmount)
            {
                money -= _reviveAmount;
                _money.text = money.ToString();

                UIManager.OnWheelPanel?.Invoke();
            }
            else
            {
                _money.color = Color.red;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _money.color = Color.white;
        }
    }
}
