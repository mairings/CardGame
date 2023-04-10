using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using CardGame.Spins;

namespace CardGame.UI
{
    public class SpinButton : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] Image _spinButtonImage;
        [SerializeField] Wheel _wheel;
        public void OnPointerDown(PointerEventData eventData)
        {
            _spinButtonImage.raycastTarget = false;
            _wheel.SpinWheel(_spinButtonImage);
            _wheel.IsSpinning = true;

        }
    }

}
