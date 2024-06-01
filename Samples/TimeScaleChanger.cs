using SBaier.DI;
using UnityEngine;

namespace SBaier.Time.Samples
{
    public class TimeScaleChanger : MonoBehaviour, Injectable
    {
        [SerializeField] 
        private float _deltaTimeScale = 0.1f;
        [SerializeField] 
        private float _minTimeScale = 0.1f;
        [SerializeField] 
        private float _maxTimeScale = 3f;
        
        private TimeService _timeService;
        private Time _time;

        public void Inject(Resolver resolver)
        {
            _timeService = resolver.Resolve<TimeService>();
            _time = resolver.Resolve<Time>();
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.KeypadPlus) || Input.GetKeyDown(KeyCode.Plus))
            {
                ChangeTimeScale(_time.TimeScale.Value + _deltaTimeScale);
            }

            if (Input.GetKeyDown(KeyCode.KeypadMinus) || Input.GetKeyDown(KeyCode.Minus))
            {
                ChangeTimeScale(_time.TimeScale.Value - _deltaTimeScale);
            }
        }

        private void ChangeTimeScale(float timeScaleValue)
        {
            _timeService.SetScale(Mathf.Clamp(timeScaleValue, _minTimeScale, _maxTimeScale));
        }
    }
}