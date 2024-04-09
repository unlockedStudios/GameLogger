using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnlockedStudios.Logger;

namespace UnlockedStudios.Notifications
{

    public class NotificationCoreServiceComponent : MonoBehaviour, INotificationCoreServiceWrapper
    {
        public event Action<string> NotificationAdded { add => _notificationCoreSvc.NotificationAdded += value; remove => _notificationCoreSvc.NotificationAdded -= value; }
        public bool IsInitialized { get; private set; }

        private INotificationCoreService _notificationCoreSvc;

        public void Initialize()
        {
            IsInitialized = true;
            _notificationCoreSvc = new NotificationCoreService();
        }

        public void Initialize(ILogCoreServiceNotif logger)
        {
            logger.LogInfo("Initializing the NotificationCoreService...");
            _notificationCoreSvc = new NotificationCoreService();
            _notificationCoreSvc.Initialize(logger);
            IsInitialized = true;
        }

        public void AddPlayerAlert(string message)
        {
            _notificationCoreSvc.AddPlayerAlert(message);
        }

        public string PlayerAlertStylized(string message, string value)
        {
            return _notificationCoreSvc.PlayerAlertStylized(message, value);
        }

        public string PlayerAlertStylized(string message, string value, AlertType alertType)
        {
            return _notificationCoreSvc.PlayerAlertStylized(message, value, alertType);
        }
    }
}