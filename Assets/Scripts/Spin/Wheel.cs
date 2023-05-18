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
        public List<float> StopAngles;
        public bool IsSpinning;
        public bool IsBomb;

        [Header("Scripts")]
        [SerializeField] SpinController _spinScript;
        [SerializeField] Counter _counterScript;


        [Header("Datas")]
        [SerializeField] WheelData _wheelData;

        private void Start()
        {
            IsSpinning = false;
            SlicesTransformsGetListing();
        }

        // when spin wheel process
        public void SpinWheel(Image spinbutton)
        {
            int level = PlayerPrefsManager.Instance.CurrentLevel+1;

            //Silver
            if (level % _wheelData.SilverLevel == 0 && level % _wheelData.GoldLevel != 0 && level != 0)
            {
                _spinScript.PanelBackgroundChange(3);
            }
            //Gold
            else if (level % _wheelData.GoldLevel == 0 && level != 0)
            {
                _spinScript.PanelBackgroundChange(2);
            }
            //Bronze
            else
            {
                _spinScript.PanelBackgroundChange(1);
            }

            //Variables for spin
            //int spinCount = Random.Range(_wheelData.MinimumSpinCount, _wheelData.MaxSpinCount + 1);
            float targetAngle = _wheelData.SpinCount * _wheelData.RotateAngleLimit;
            int randomAngleIndex = Random.Range(0, StopAngles.Count);
            targetAngle += StopAngles[randomAngleIndex];
            int sliceCount = SliceTransforms.Count;
            float sliceAngle = _wheelData.RotateAngleLimit / sliceCount;
            float currentAngle = WheelTransform.rotation.eulerAngles.z;
            float deltaAngle = targetAngle - currentAngle;
            float fullRotations = Mathf.Floor(deltaAngle / _wheelData.RotateAngleLimit);
            float finalAngle = targetAngle - fullRotations * _wheelData.RotateAngleLimit;

            //Rotate Animations
            Sequence spinSequence = DOTween.Sequence();
            spinSequence.Append(WheelTransform.DOLocalRotate(new Vector3(0f, 0f, currentAngle + fullRotations * _wheelData.RotateAngleLimit), 
                                                                                                _wheelData.RotationTime * 0.2f));
            spinSequence.Append(WheelTransform.DOLocalRotate(new Vector3(0f, 0f, targetAngle - sliceAngle),
                                    _wheelData.RotationTime * 0.3f, RotateMode.FastBeyond360)).SetEase(Ease.OutQuint);
            
            IsSpinning = false;

            spinSequence.OnComplete(() => {

                spinbutton.raycastTarget = true;
                UIManager.OnRewardPanel?.Invoke();
                RewardCard.Instance.SetCardContent(_spinScript.ContentHolesList[randomAngleIndex].GetComponent<ContentHole>().Reward.sprite,
                       _spinScript.ContentHolesList[randomAngleIndex].GetComponent<ContentHole>().Amount);

                PlayerPrefsManager.Instance.CurrentLevel++;

                _spinScript.GetSpinDatasLevel();
                _spinScript.PanelBackgroundChange(0);
                _counterScript.UpdateCounter();

            });
          

            spinSequence.Play();
        }
     
        private void SlicesTransformsGetListing()
        {
            float AngleIncrease = 0;
            foreach (GameObject item in _spinScript.ContentHolesList)
            {
                SliceTransforms.Add(item.transform);
            }

            for (int i = 0; i < _spinScript.ContentHolesList.Count; i++)
            {
                StopAngles.Add(0 - AngleIncrease);
                AngleIncrease-=_wheelData.AngleIncreaseAmount;
            }
        }

    }
}
