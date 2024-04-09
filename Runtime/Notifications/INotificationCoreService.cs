using System;
using UnlockedStudios.Logger;

namespace UnlockedStudios.Notifications
{
    public interface INotificationCoreService : INotificationAlerts
    {
        /// <summary>
        /// Used to Initialize the LogCoreService with the Logger.
        /// </summary>
        /// <param name="logger"></param>
        void Initialize(ILogCoreServiceNotif logger);

        /// <summary>
        /// Used to Notify listeners when a notification has occurred.
        /// </summary>
        event Action<string> NotificationAdded;
    }
}