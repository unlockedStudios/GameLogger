using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UnlockedStudios.Notifications.UIControllers
{
    public class VENotificationLabel : VisualElement
    {
        public TextElement label;
        public int Id { get; private set; }

        public VENotificationLabel(string txt, int countId)
        {
            this.pickingMode = PickingMode.Ignore;
            Id = countId;
            
            label = new TextElement();
            label.enableRichText = true;
            label.text = txt;
            label.pickingMode = PickingMode.Ignore;
            label.AddToClassList(VENotificationConstants.NotificationLabel);

            this.Add(label);
        }
    }
}