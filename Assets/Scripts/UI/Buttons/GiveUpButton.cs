using UnityEngine;
using UnityEngine.EventSystems;
using CardGame.Manager;

namespace CardGame.UI
{
    public class GiveUpButton : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            UIManager.OnGameReset?.Invoke();
        }
    }
}
