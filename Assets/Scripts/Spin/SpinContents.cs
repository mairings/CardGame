using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame.Spin
{
    public class SpinContents : MonoBehaviour
    {
        [SerializeField] GameObject _holeContentPrefab;
        [SerializeField] SpinDatas _spinDataBronze, _spinDataSilver, _spinDataGold;
        private void Awake()
        {
            HoleGenerator();
        }
        private void Start()
        {
            
        }
        void HoleGenerator()
        {
            float quaternionZ=0;
                for (int i = 0; i < 8; i++)
                {
                    GameObject hole = Instantiate(_holeContentPrefab, transform.position, Quaternion.Euler(0,0,quaternionZ), transform);
                    quaternionZ -= 45;
                    Spin.Instance.ContentHolesList.Add(hole);
                }
        }


    }
}
