using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Source.Scripts
{
    public class Counter : MonoBehaviour
    {
        [SerializeField] private float _delayTime = 0.5f;
        [SerializeField] private bool _isWorking = true;

        private bool _isCountingSwitchOn = false;

        public int Value { get; private set; }

        public event Action OnValueChanged;

        private void Start()
        {
            Value = 0;

            OnValueChanged?.Invoke();

            StartCoroutine(Countup());
        }

        private IEnumerator Countup()
        {
            WaitForSeconds wait = new WaitForSeconds(_delayTime);

            while (_isWorking)
            {
                yield return new WaitUntil(() => _isCountingSwitchOn == true);
                
                IncreaseValue();

                OnValueChanged?.Invoke();

                yield return wait;
            }
        }

        private void IncreaseValue()
        {
            Value++;
        }

        public void SwitchCounting()
        {
            switch (_isCountingSwitchOn)
            {
                case false:
                    _isCountingSwitchOn = true;
                    break;
                case true:
                    _isCountingSwitchOn = false;
                    break;
            }
        }
    }
}