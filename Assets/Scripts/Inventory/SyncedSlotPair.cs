using System;
using Slots;

namespace Inventory
{
    [Serializable]
    public struct SyncedSlotPair
    {
        public SlotBase slotOne;
        public SlotBase slotTwo;
    }
}