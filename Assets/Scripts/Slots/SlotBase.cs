using UnityEngine;

namespace Slots
{
   public abstract class SlotBase : MonoBehaviour, ISlot
   {
      public AddItemEvent OnItemAdded;
      public RemoveItemEvent OnItemRemoved;

      public virtual void SyncAddItem(ItemData item,int slotId) { }
      public abstract void SyncRemoveItem(ItemData item,int slotId,Pose? pose);
   }
}