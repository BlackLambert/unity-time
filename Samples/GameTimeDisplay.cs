using SBaier.DI;
using TMPro;
using UnityEngine;

namespace SBaier.Time.Samples
{
    public class GameTimeDisplay : MonoBehaviour, Injectable
    {
        [SerializeField] 
        private TextMeshProUGUI _text;

        private Time _time;

        public void Inject(Resolver resolver)
        {
            _time = resolver.Resolve<Time>();
        }

        private void Update()
        {
            SetText();
        }

        private void SetText()
        {
            _text.text = $"Gametime: {_time.CurrentTime:F1}";
        }
    }
}