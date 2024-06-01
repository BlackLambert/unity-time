namespace SBaier.Time
{
    public class UnityTime : Time
    {
        public ReadonlyObservable<bool> Paused => MutablePaused;
        public ReadonlyObservable<float> TimeScale => MutableTimeScale;
        public float CurrentTime => UnityEngine.Time.time;
        public float DeltaTime => UnityEngine.Time.deltaTime;
        public float CurrentUnscaledTime => UnityEngine.Time.unscaledTime;
        public float UnscaledDeltaTime => UnityEngine.Time.unscaledDeltaTime;

        public readonly Observable<bool> MutablePaused;
        public readonly Observable<float> MutableTimeScale;
        public float FormerTimeScale;

        public UnityTime()
        {
            MutablePaused = new Observable<bool>() { Value = UnityEngine.Time.timeScale == 0 };
            MutableTimeScale = new Observable<float>() { Value = UnityEngine.Time.timeScale };
            FormerTimeScale = UnityEngine.Time.timeScale;
        }
    }
}