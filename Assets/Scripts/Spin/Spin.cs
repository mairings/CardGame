using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CardGame.Spin
{
    public class Spin : Singleton<Spin>
    {
        public List<GameObject> ContentHolesList = new List<GameObject>();
        [SerializeField]SpinUIData _spinUIData;

        [SerializeField] Image _spinImg, _indicatorImg, _buttonSpinImg;
        

        void SpinContentsGet(Image spinImg, Image indicatorImg, Image buttonSpinImg)
        {
            _spinImg = spinImg;
            _indicatorImg = indicatorImg;
            _buttonSpinImg = buttonSpinImg;
        }



    }
}
