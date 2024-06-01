using System;

namespace SBaier.Time
{
    public interface TimeService
    {
        TimeSpan CalculateTimeSpan(float startTime, float endTime);
        void SetScale(float scale);
        void Pause();
        void Unpause();
    }
}