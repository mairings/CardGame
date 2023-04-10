using UnityEngine;

namespace CardGame.Spins
{
    public class SpinContents : MonoBehaviour
    {
        [SerializeField] GameObject _holeContentPrefab;
        [SerializeField] SpinController _spinController;

        private void Awake()
        {
            HoleGenerator();
        }

        void HoleGenerator()
        {
            float quaternionZ=45;
                for (int i = 0; i < 8; i++)
                {
                    GameObject hole = Instantiate(_holeContentPrefab, transform.position, 
                                            Quaternion.Euler(0,0,quaternionZ), transform);
                    _spinController.ContentHolesList.Add(hole);
                    quaternionZ -= 45;
                }
        }


    }
}
