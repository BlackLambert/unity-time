namespace SBaier.Time
{
    public interface Time
    {
        ReadonlyObservable<bool> Paused { get; }
        ReadonlyObservable<float> TimeScale { get; }
        float CurrentTime { get; }
        float DeltaTime { get; }
        float CurrentUnscaledTime { get; }
        float UnscaledDeltaTime { get; }
    }
}