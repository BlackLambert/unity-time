using SBaier.DI;
using TMPro;
using UnityEngine;

namespace SBaier.Time.Samples
{
    public class PausedDisplay : MonoBehaviour, Injectable, Initializable, Cleanable
    {
        private const string _pausedTextAddition = "paused";
        private const string _runningTextAddition = "running";
        
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
            _time.Paused.OnValueChanged += OnPausedChanged;
        }

        public void Clean()
        {
            _time.Paused.OnValueChanged -= OnPausedChanged;
        }

        private void OnPausedChanged(bool formervalue, bool newvalue)
        {
            SetText();
        }

        private void SetText()
        {
            string textAddition = _time.Paused.Value ? _pausedTextAddition : _runningTextAddition;
            _text.text = $"The game is {textAddition}.";
        }
    }
}