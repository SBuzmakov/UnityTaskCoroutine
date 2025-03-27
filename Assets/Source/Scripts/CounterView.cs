using TMPro;
using UnityEngine;

namespace Source.Scripts
{
    public class CounterView : MonoBehaviour
    {
        [SerializeField] private Counter _counter;
        [SerializeField] private TextMeshProUGUI  _counterValueText;

        private void OnEnable()
        {
            _counter.OnValueChanged += UpdateCounterView;
        }

        private void OnDisable()
        {
            _counter.OnValueChanged -= UpdateCounterView;
        }
    
        private void UpdateCounterView()
        {
            _counterValueText.text = _counter.Value.ToString();
        }
    }
}
