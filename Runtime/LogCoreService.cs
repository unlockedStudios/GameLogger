using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnlockedStudios.GameLogger.Logger;
using UnlockedStudios.Logger;
using UnlockedStudios.Notifications;

namespace VoV.Logger
{
    public class LogCoreService : ILogCoreServiceNotif
    {
        private IGameLogger _gameLogger;
        private INotificationCoreService _notificationCoreService;

        public LogCoreService()
        {
            _gameLogger = new GameLogger();
            EnableFileLogger(true);
        }

        public void AddNotificationSvc(INotificationCoreService notificationService)
        {
            this.LogInfo("Adding Player Notification Package.");
            _notificationCoreService = notificationService;
        }

        public void NotificationPlayerAlert(string message,
            [CallerMemberName] string methodName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (_notificationCoreService != null)
                _notificationCoreService.AddPlayerAlert(message);
            LogInfo(message, methodName, sourceFilePath, sourceLineNumber);
        }

        public string NotificationPlayerAlertStylized(string message, string value,
            [CallerMemberName] string methodName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            string ret = string.Format(message, value);
            if (_notificationCoreService != null)
                ret = _notificationCoreService.PlayerAlertStylized(message, value);
            LogInfo(ret, methodName, sourceFilePath, sourceLineNumber);

            return ret;
        }

        public string NotificationPlayerAlertStylized(string message, string value, AlertType alertType,
            [CallerMemberName] string methodName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            string ret = string.Format(message, value);
            if (_notificationCoreService != null)
                ret = _notificationCoreService.PlayerAlertStylized(message, value, alertType);
            LogInfo(ret, methodName, sourceFilePath, sourceLineNumber);

            return ret;
        }

        public void EnableFileLogger(bool enable)
        {
            _gameLogger.EnableFileLogger(enable);

            this.LogInfo(@"   _____ _             _     ______ _ _        _                                 ");
            this.LogInfo(@"  / ____| |           | |   |  ____(_) |      | |                                ");
            this.LogInfo(@" | (___ | |_ __ _ _ __| |_  | |__   _| | ___  | |     ___   __ _  __ _  ___ _ __ ");
            this.LogInfo(@"  \___ \| __/ _` | '__| __| |  __| | | |/ _ \ | |    / _ \ / _` |/ _` |/ _ \ '__|");
            this.LogInfo(@"  ____) | || (_| | |  | |_  | |    | | |  __/ | |___| (_) | (_| | (_| |  __/ |   ");
            this.LogInfo(@" |_____/ \__\__,_|_|   \__| |_|    |_|_|\___| |______\___/ \__, |\__, |\___|_|   ");
            this.LogInfo(@"                                                            __/ | __/ |          ");
            this.LogInfo(@"                                                           |___/ |___/           ");
        }

        public void LogDebug(string message,
            [CallerMemberName] string methodName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            _gameLogger.LogDebug(message, methodName, sourceFilePath, sourceLineNumber);
        }

        public void LogError(string message,
            [CallerMemberName] string methodName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            _gameLogger.LogError(message, methodName, sourceFilePath, sourceLineNumber);
        }

        public void LogError(string message, Exception ex,
            [CallerMemberName] string methodName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            _gameLogger.LogError(message, ex, methodName, sourceFilePath, sourceLineNumber);
        }

        public void LogInfo(string message,
            [CallerMemberName] string methodName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            _gameLogger.LogInfo(message, methodName, sourceFilePath, sourceLineNumber);
        }

        public void LogWarning(string message,
            [CallerMemberName] string methodName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            _gameLogger.LogWarning(message, methodName, sourceFilePath, sourceLineNumber);
        }
    }
}