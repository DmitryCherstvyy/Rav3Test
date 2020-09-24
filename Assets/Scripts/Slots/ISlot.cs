using UnityEngine;

namespace Slots
{
    public interface ISlot
    {
        void SyncAddItem(ItemData item,int slotId);
        void SyncRemoveItem(ItemData item,int slotId,Pose? pose);
    }
}