using System.Collections;

namespace UnlockedStudios.Notifications
{
    public interface INotificationCoreServiceWrapper : INotificationCoreService
    {
        bool IsInitialized { get;}
        void Initialize();
    }
}