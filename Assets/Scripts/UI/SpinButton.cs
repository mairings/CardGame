using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using CardGame.Spin;
using UnityEngine.UI;

namespace CardGame.UI
{
    public class SpinButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] Image _spinButtonImage;
        public void OnPointerDown(PointerEventData eventData)
        {
            _spinButtonImage.raycastTarget = false;
            Wheel.Instance.SpinWheel(_spinButtonImage);
            Wheel.Instance.IsSpinning = true;

        }

        public void OnPointerUp(PointerEventData eventData)
        {
            
        }
    }
}
