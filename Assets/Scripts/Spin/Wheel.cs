using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using CardGame.Cards;
using UnityEngine.UI;
using CardGame.Manager;
using CardGame.UI;

namespace CardGame.Spins
{
    public class Wheel : MonoBehaviour
    {
        [Header("Wheel Spin Mechanic")]
        public Transform WheelTransform;
        public Transform Pointer;
        [HideInInspector]public List<Transform> SliceTransforms;
        [SerializeField] float _rotationTime = 5f;
        [SerializeField] int _minSpinCount = 3;
        [SerializeField] int _maxSpinCount = 6;
        public List<float> StopAngles;
        public bool IsSpinning;
        public bool IsBomb;

        [Header("Scripts")]
        [SerializeField] SpinController _spinScript;
        [SerializeField] Counter _counterScript;


        void Start()
        {
            IsSpinning = false;
            SlicesTransformsGetListing();
        }

        // when spin wheel process
        public void SpinWheel(Image spinbutton)
        {
            int level = PlayerPrefs.GetInt("Level")+1;

            //Silver
            if (level % 5 == 0 && level % 30 != 0 && level != 0)
            {
                _spinScript.PanelBackgroundChange(3);
            }
            //Gold
            else if (level % 30 == 0 && level != 0)
            {
                _spinScript.PanelBackgroundChange(2);
            }
            //Bronze
            else
            {
                _spinScript.PanelBackgroundChange(1);
            }

           //Variables for spin
            int spinCount = Random.Range(_minSpinCount, _maxSpinCount + 1);
            float targetAngle = spinCount * 360f;
            int randomAngleIndex = Random.Range(0, StopAngles.Count);
            targetAngle += StopAngles[randomAngleIndex];
            int sliceCount = SliceTransforms.Count;
            float sliceAngle = 360f / sliceCount;
            float currentAngle = WheelTransform.rotation.eulerAngles.z;
            float deltaAngle = targetAngle - currentAngle;
            float fullRotations = Mathf.Floor(deltaAngle / 360f);
            float finalAngle = targetAngle - fullRotations * 360f;

            //Rotate Animations
            Sequence spinSequence = DOTween.Sequence();
            spinSequence.Append(WheelTransform.DOLocalRotate(new Vector3(0f, 0f, currentAngle + fullRotations * 360f), 
                                                                                                _rotationTime * 0.2f));
            spinSequence.Append(WheelTransform.DOLocalRotate(new Vector3(0f, 0f, targetAngle - sliceAngle),
                                    _rotationTime * 0.3f, RotateMode.FastBeyond360)).SetEase(Ease.OutQuint);
            
            IsSpinning = false;

            spinSequence.OnComplete(() => {

                spinbutton.raycastTarget = true;
                UIManager.OnRewardPanel?.Invoke();
                RewardCard.Instance.SetCardContent(_spinScript.ContentHolesList[randomAngleIndex].GetComponent<ContentHole>().Reward.sprite,
                       _spinScript.ContentHolesList[randomAngleIndex].GetComponent<ContentHole>().Amount.text.Substring(1));
                PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
                _spinScript.GetSpinDatasLevel();
                _spinScript.PanelBackgroundChange(0);
                _counterScript.UpdateCounter();

            });
          

            spinSequence.Play();
        }
        void SlicesTransformsGetListing()
        {
            float AngleIncrease = 0;
            foreach (GameObject item in _spinScript.ContentHolesList)
            {
                SliceTransforms.Add(item.transform);
            }

            for (int i = 0; i < _spinScript.ContentHolesList.Count; i++)
            {
                StopAngles.Add(0 - AngleIncrease);
                AngleIncrease-=45;
            }
        }

    }
}
