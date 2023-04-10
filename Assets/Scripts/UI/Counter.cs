using UnityEngine;
using TMPro;

namespace CardGame.UI
{
    public class Counter : MonoBehaviour
    {
        [SerializeField]TextMeshProUGUI _counterTextPrevios, _counterTextCurrent, _counterTextNext;
        [SerializeField]GameObject _goldFrame, _sliverFrame;
        private void Start()
        {
            UpdateCounter();
        }

        public void UpdateCounter()
        {
            int level = PlayerPrefs.GetInt("Level");
            if (level  == 0)
            {
                _counterTextPrevios.text = "";
            }
            else
            {
                _counterTextPrevios.text = (level).ToString();
            }

            _counterTextCurrent.text = (level + 1).ToString();
            _counterTextNext.text = (level + 2).ToString();
            
            if ((level + 1) % 5 == 0 && level+1 != 30)
            {
                if (_goldFrame.activeSelf) _goldFrame.SetActive(false);

                _sliverFrame.SetActive(true);
            }
            else if ((level + 1) % 30 == 0)
            {
                if (_sliverFrame.activeSelf) _sliverFrame.SetActive(false);
                
                _goldFrame.SetActive(true);
            }
            else
            {
                _goldFrame.SetActive(false);
                _sliverFrame.SetActive(false);
            }
        }

    }
}
