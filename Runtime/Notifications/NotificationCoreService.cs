using System;
using System.Collections;
using System.Collections.Generic;
using UnlockedStudios.Logger;

namespace UnlockedStudios.Notifications
{
    public class NotificationCoreService : INotificationCoreService
    {
        private string _stylizedColor;

        public event Action<string> NotificationAdded;

        public void Initialize(ILogCoreServiceNotif logger)
        {
            DetermineStylizedColor(AlertType.Default);
            logger.LogInfo("Tieing the NotificationCoreService to the Logger Component..");
            logger.AddNotificationSvc(this);
        }

        public void AddPlayerAlert(string message)
        {
            NotificationAdded?.Invoke(message);
        }

        public string StylizedAlert(string message, params object[] args)
        {
            DetermineStylizedColor(AlertType.Default);
            return StylizedMessageAlert(message, args);
        }

        private string StylizedMessageAlert(string message, params object[] args)
        {
            string[] argsAllStylized = new string[args.Length];
            string stylizedText = $"<color={_stylizedColor}>";
            string stylizedTextEnd = "</color>";

            for (int i = 0; i < args.Length; i++)
                argsAllStylized[i] = string.Concat(stylizedText, args[i], stylizedTextEnd);

            string messageStylized = string.Format(message, argsAllStylized);
            string messageNormal = string.Format(message, args);
            NotificationAdded?.Invoke(messageStylized);

            return messageNormal;
        }

        public string PlayerAlertStylized(string message, string value)
        {
            DetermineStylizedColor(AlertType.Default);
            string ret = StylizedMessageAlert(message, value);
            return ret;
        }

        public string PlayerAlertStylized(string message, string value, AlertType alertType)
        {
            DetermineStylizedColor(alertType);
            string ret = StylizedMessageAlert(message, value);
            return ret;
        }

        private void DetermineStylizedColor(AlertType aType)
        {
            switch (aType) { 
                case AlertType.Achievement:
                    _stylizedColor = NotificationColors.Orange;
                    break;
                case AlertType.Damage:
                    _stylizedColor = NotificationColors.Red;
                    break;
                case AlertType.Experience:
                    _stylizedColor = NotificationColors.Purple;
                    break;
                case AlertType.Item:
                    _stylizedColor = NotificationColors.Green;
                    break;
                case AlertType.Currency:
                    _stylizedColor = NotificationColors.Yellow;
                    break;
                case AlertType.Skills:
                    _stylizedColor = NotificationColors.LightBlue;
                    break;
                case AlertType.Default:
                default:
                    _stylizedColor = NotificationColors.ColorDefault;
                    break;
            }
        }
    }
}