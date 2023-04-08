using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame.Spin
{
    public class SpinContents : MonoBehaviour
    {
        [SerializeField] GameObject _holeContentPrefab;
        private void Awake()
        {
            HoleGenerator();
        }

        void HoleGenerator()
        {
            float quaternionZ=45;
                for (int i = 0; i < 8; i++)
                {
                    GameObject hole = Instantiate(_holeContentPrefab, transform.position, Quaternion.Euler(0,0,quaternionZ), transform);
                    Spin.Instance.ContentHolesList.Add(hole);
                    quaternionZ -= 45;
                }
        }


    }
}
