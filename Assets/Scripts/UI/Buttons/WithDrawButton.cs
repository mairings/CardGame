using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace CardGame.UI
{
    public class WithDrawButton : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            RewardInfo.OnSaveRewards?.Invoke();
            PlayerPrefs.DeleteKey("Level");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
