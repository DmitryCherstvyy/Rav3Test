using Server;
using Slots;
using UnityEngine;

namespace Inventory
{
    /// <summary>
    /// adds references on start
    /// </summary>
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] SyncedSlotPair[] slots;

        void Start()
        {
            foreach (var pairOfSlots in slots)
            {
                var one = pairOfSlots.slotOne;
                var two = pairOfSlots.slotTwo;

                //subscriptions to sync changes between 2d and 
                if (one is UISlot uiSlot && two is MeshSlot meshSlot) 
                    uiSlot.referenceOf3DInstance = meshSlot.ItemInstance;

                one.OnItemAdded.AddListener(two.SyncAddItem);
                one.OnItemRemoved.AddListener(two.SyncRemoveItem);
            
                two.OnItemAdded.AddListener(one.SyncAddItem);
                two.OnItemRemoved.AddListener(one.SyncRemoveItem);
            
                //adding server Sync
            
                one.OnItemAdded.AddListener(ServerSyncAddItem);
                two.OnItemAdded.AddListener(ServerSyncAddItem);
            
                one.OnItemRemoved.AddListener(ServerSyncRemoveItem);
                two.OnItemRemoved.AddListener(ServerSyncRemoveItem);
            }
        }

        void ServerSyncAddItem(ItemData item, int slotId) =>
            ServerCommandManager.AddCommand(InventoryCommands.AddItemFromServerCommand(item.id));
        void ServerSyncRemoveItem(ItemData item, int slotId,Pose? pose) =>
            ServerCommandManager.AddCommand(InventoryCommands.RemoveItemFromServerCommand(item.id));
    }
}