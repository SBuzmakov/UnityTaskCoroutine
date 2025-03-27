using System;
using System.Collections;
using UnityEngine;

namespace Source.Scripts
{
    public class Counter : MonoBehaviour
    {
        [SerializeField] private float _delayTime = 0.5f;
        [SerializeField] private bool _isWorking = true;
        [SerializeField] private Input _input;

        private Coroutine _coroutine;
        private bool _isCounting = true;

        public event Action OnValueChanged;

        public int Value { get; private set; }

        private void OnEnable()
        {
            _input.OnMouseButtonPressed += SwitchCounting;
        }

        private void OnDisable()
        {
            _input.OnMouseButtonPressed -= SwitchCounting;
        }

        private void Start()
        {
            Value = 0;

            OnValueChanged?.Invoke();

            _coroutine = StartCoroutine(Countup());
        }

        private IEnumerator Countup()
        {
            WaitForSeconds wait = new WaitForSeconds(_delayTime);

            while (_isWorking)
            {
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
            if (_isCounting)
                StopCoroutine(_coroutine);
            else
                _coroutine = StartCoroutine(Countup());

            _isCounting = !_isCounting;
        }
    }
}