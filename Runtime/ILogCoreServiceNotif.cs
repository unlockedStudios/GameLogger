using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnlockedStudios.Notifications;

namespace UnlockedStudios.Logger
{
    public interface ILogCoreServiceNotif : ILogCoreService
    {
        void AddNotificationSvc(INotificationCoreService notificationService);
    }
}