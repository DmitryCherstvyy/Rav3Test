using System;
using UnityEngine;
using UnityEngine.Events;

namespace Slots
{
    [Serializable]
    public class RemoveItemEvent : UnityEvent<ItemData,int,Pose?>{ }
}