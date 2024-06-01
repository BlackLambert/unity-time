using SBaier.DI;
using TMPro;
using UnityEngine;

namespace SBaier.Time.Samples
{
    public class TimeScaleDisplay : MonoBehaviour, Initializable, Injectable, Cleanable
    {
        [SerializeField] 
        private TextMeshProUGUI _text;

        private Time _time;

        public void Inject(Resolver resolver)
        {
            _time = resolver.Resolve<Time>();
        }
        
        public void Initialize()
        {
            SetText();
            _time.TimeScale.OnValueChanged += OnTimeScaleChanged;
        }

        public void Clean()
        {
            _time.TimeScale.OnValueChanged -= OnTimeScaleChanged;
        }

        private void OnTimeScaleChanged(float formerValue, float newValue)
        {
            SetText();
        }

        private void SetText()
        {
            _text.text = $"Time scale: {_time.TimeScale.Value}.";
        }
    }
}