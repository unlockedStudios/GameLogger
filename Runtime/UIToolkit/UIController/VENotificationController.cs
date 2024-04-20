using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using UnlockedStudios.Notifications;

namespace UnlockedStudios.Notifications.UIControllers
{
    public class VENotificationController : MonoBehaviour
    {
        
        public List<VisualElement> MouseDetectionVisualElements { get; private set; }

        public bool IsHUDUI => true;

        private INotificationCoreServiceWrapper _notificationCoreService;

        private int _maxTextLimit = 50;

        private int _currentCount = 0;
        public VisualElement Container { get; private set; }
        private ScrollView _notificationScroller { get; set; }


        private List<VENotificationLabel> _txtNotifications;

        private VENotificationLabel _lastLabelElement;


        private void Awake()
        {
            _notificationCoreService = gameObject.GetComponent<NotificationCoreServiceComponent>();
            _notificationCoreService.NotificationAdded += UIAddNotification;
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            _txtNotifications = new List<VENotificationLabel>();

            Container = root.Q<VisualElement>(VENotificationConstants.Notification);
            _notificationScroller = Container.Q<ScrollView>(VENotificationConstants.NotificationScroller);
            MouseDetectionVisualElements = new List<VisualElement>();
            MouseDetectionVisualElements.Add(Container);
        }

        private void OnDisable()
        {
            if (_notificationCoreService == null) return;
            _notificationCoreService.NotificationAdded -= UIAddNotification;
        }

        private void UIAddNotification(string message)
        {
            _currentCount = _currentCount + 1;
            VENotificationLabel veLabelRow = new VENotificationLabel(message, _currentCount);
            
            //remove last entry.
            if(_currentCount >= _maxTextLimit)
            {
                VENotificationLabel notif = _txtNotifications.First();

                bool bOk = _txtNotifications.Remove(notif);
                _notificationScroller.Remove(notif);
            }

            //add new entry.
            _lastLabelElement = veLabelRow;
            _txtNotifications.Add(veLabelRow);
            _notificationScroller.Insert(0, veLabelRow);
        }
    }
}