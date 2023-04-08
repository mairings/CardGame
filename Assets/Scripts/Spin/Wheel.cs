using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using CardGame.Cards;
using UnityEngine.UI;

namespace CardGame.Spin
{
    public class Wheel : Singleton<Wheel>
    {
        [Header("Wheel Spin Mechanic")]
        public Transform wheel;
        public Transform pointer;
        public List<Transform> sliceTransforms;
        public float rotationTime = 5f;
        public int minSpinCount = 3;
        public int maxSpinCount = 6;
        public List<float> stopAngles;
        public bool IsSpinning;

        [SerializeField]Spin _spinScript;

        void Start()
        {
            IsSpinning = false;
            SlicesTransformsGetListing();
        }

        public void SpinWheel(Image spinbutton)
        {
            _spinScript.GetSpinDatasLevel();

            int spinCount = Random.Range(minSpinCount, maxSpinCount + 1);
            float targetAngle = spinCount * 360f;
            int randomAngleIndex = Random.Range(0, stopAngles.Count);
            targetAngle += stopAngles[randomAngleIndex];
            int sliceCount = sliceTransforms.Count;
            float sliceAngle = 360f / sliceCount;
            float currentAngle = wheel.rotation.eulerAngles.z;
            float deltaAngle = targetAngle - currentAngle;
            float fullRotations = Mathf.Floor(deltaAngle / 360f);
            float finalAngle = targetAngle - fullRotations * 360f;

            Sequence spinSequence = DOTween.Sequence();
            spinSequence.Append(wheel.DOLocalRotate(new Vector3(0f, 0f, currentAngle + fullRotations * 360f), rotationTime * 0.2f));
            spinSequence.Append(wheel.DOLocalRotate(new Vector3(0f, 0f, targetAngle - sliceAngle), rotationTime * 0.3f, RotateMode.FastBeyond360)).SetEase(Ease.OutQuint);
            
            RewardCard.Instance.SetCardContent(_spinScript.ContentHolesList[randomAngleIndex].GetComponent<ContentHole>().Reward.sprite,
                   _spinScript.ContentHolesList[randomAngleIndex].GetComponent<ContentHole>().Amount.text);
            IsSpinning = false;
            spinSequence.OnComplete(() => {
                spinbutton.raycastTarget = true;
            });
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);

            spinSequence.Play();
        }
        void SlicesTransformsGetListing()
        {
            float AngleIncrease = 0;
            foreach (GameObject item in _spinScript.ContentHolesList)
            {
                sliceTransforms.Add(item.transform);
            }

            for (int i = 0; i < _spinScript.ContentHolesList.Count; i++)
            {
                stopAngles.Add(0 - AngleIncrease);
                AngleIncrease-=45;
            }
        }

        void GetRewardCard()
        {

        }
    
    }
}
