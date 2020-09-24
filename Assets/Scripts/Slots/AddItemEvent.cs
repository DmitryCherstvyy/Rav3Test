using System;
using UnityEngine.Events;

namespace Slots
{
    [Serializable]
    public class AddItemEvent : UnityEvent<ItemData,int>{ }
}