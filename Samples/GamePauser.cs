using SBaier.DI;
using UnityEngine;

namespace SBaier.Time.Samples
{
    public class GamePauser : MonoBehaviour, Injectable
    {
        private TimeService _timeService;
        private Time _time;

        public void Inject(Resolver resolver)
        {
            _timeService = resolver.Resolve<TimeService>();
            _time = resolver.Resolve<Time>();
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Pause))
            {
                return;
            }
            
            if (_time.Paused.Value)
            {
                _timeService.Unpause();
            }
            else
            {
                _timeService.Pause();
            }
        }
    }
}