using System;
using SBaier.DI;

namespace SBaier.Time
{
    public class UnityTimeService : TimeService, Injectable
    {
        private UnityTime _unityTime;
        
        public void Inject(Resolver resolver)
        {
            _unityTime = resolver.Resolve<UnityTime>();
        }
        
        public TimeSpan CalculateTimeSpan(float startTime, float endTime)
        {
            return TimeSpan.FromSeconds(endTime - startTime);
        }

        public void SetScale(float scale)
        {
            if (scale < 0)
            {
                throw new InvalidOperationException("The time scale can not be less than 0.");
            }
            
            UnityEngine.Time.timeScale = scale;
            _unityTime.MutableTimeScale.Value = scale;
        }

        public void Pause()
        {
            if (_unityTime.Paused.Value)
            {
                throw new InvalidOperationException("Pausing failed. The time is already paused.");
            }
            
            _unityTime.FormerTimeScale = _unityTime.TimeScale.Value;
            SetScale(0);
            _unityTime.MutablePaused.Value = true;
        }

        public void Unpause()
        {
            if (!_unityTime.Paused.Value)
            {
                throw new InvalidOperationException("Unpausing failed. The time is not paused.");
            }
            
            SetScale(_unityTime.FormerTimeScale);
            _unityTime.MutablePaused.Value = false;
        }
    }
}