using UnityEngine;
using UnityEngine.SceneManagement;
using System;
namespace CardGame.Manager
{
    public class UIManager : MonoBehaviour
    {
        [Header("Panels")]
        [SerializeField] GameObject _wheelPanel, _rewardCardPanel, _deathPanel;
        public static Action OnRewardPanel, OnWheelPanel, OnDeathPanel, OnGameReset;

        private void OnEnable()
        {
            OnRewardPanel += GetRewardPanel;
            OnWheelPanel += GetWheelPanel;
            OnDeathPanel += GetDeathPanel;
            OnGameReset += GameReset;
        }
        private void OnDisable()
        {
            OnRewardPanel -= GetRewardPanel;
            OnWheelPanel -= GetWheelPanel;
            OnDeathPanel -= GetDeathPanel;
            OnGameReset -= GameReset;
            
        }

        public void GetRewardPanel()
        {
            _rewardCardPanel.SetActive(true);
            _wheelPanel.SetActive(false);
        }
        public void GetWheelPanel()
        {
            _rewardCardPanel.SetActive(false);
            _wheelPanel.SetActive(true);
            _deathPanel.SetActive(false);
        }
        public void GetDeathPanel()
        {
            _deathPanel.SetActive(true);
            _wheelPanel.SetActive(false);
            _rewardCardPanel.SetActive(false);
        }
        public void GameReset()
        {
            PlayerPrefsManager.Instance.ResetAllKeys();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
