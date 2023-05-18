using UnityEngine;

namespace CardGame.Spins
{
    public class SpinContents : MonoBehaviour
    {
        [SerializeField] GameObject _holeContentPrefab;
        [SerializeField] SpinController _spinController;
        [SerializeField] WheelData _data;
        private void Awake()
        {
            HoleGenerator();
        }

        void HoleGenerator()
        {
            float quaternionZ=_data.AngleIncreaseAmount;
                for (int i = 0; i < 8; i++)
                {
                    GameObject hole = Instantiate(_holeContentPrefab, transform.position, 
                                            Quaternion.Euler(0,0,quaternionZ), transform);
                    _spinController.ContentHolesList.Add(hole);
                    quaternionZ -= _data.AngleIncreaseAmount;
                }
        }


    }
}
