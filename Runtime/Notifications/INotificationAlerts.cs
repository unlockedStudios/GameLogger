using System;
using System.Collections;

namespace UnlockedStudios.Notifications
{
    public interface INotificationAlerts
    {
        /// <summary>
        /// Used to add Player Alerts. This goes straight to the UI, no stylized.
        /// </summary>
        /// <param name="message"></param>
        void AddPlayerAlert(string message);

        /// <summary>
        /// Used to stylize a notification alert.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        string PlayerAlertStylized(string message, string value);

        /// <summary>
        /// Used to stylize a notification alert.
        /// Example1: "PlayerAlertStylized("Congratulations, you have earned {0} experience", "50", alertType.Experience);
        /// Example2: "PlayerAlertStylized("You have picked up the {0} item.", contractItem.Name , alertType.Experience);
        /// </summary>
        /// <param name="message">The message to stylize.</param>
        /// <param name="value">The specific value that will be stylized.</param>
        /// <param name="alertType">The type of alert that is being sent.</param>
        /// <returns></returns>
        string PlayerAlertStylized(string message, string value, AlertType alertType);
    }
}