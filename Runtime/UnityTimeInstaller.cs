using SBaier.DI;

namespace SBaier.Time
{
    public class UnityTimeInstaller : MonoInstaller
    {
        public override void InstallBindings(Binder binder)
        {
            UnityTime time = new UnityTime();
            binder.Bind<Time>()
                .ToInstance(time)
                .WithInjection();
            
            binder.Bind<TimeService>()
                .ToNew<UnityTimeService>()
                .WithArgument(time)
                .AsSingle();
        }
    }
}