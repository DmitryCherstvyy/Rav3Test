using UnityEngine;

namespace Slots
{
    public class MeshSlot : SlotBase
    {
        // can be moved to ScriptableObject object
        readonly Color m_CorrectSlot = Color.yellow/1.9f;
        readonly Color m_IncorrectSlot = Color.red/1.9f;
        
        [SerializeField] int groupId;
        [SerializeField] Renderer highlightRenderer; 
        
        public ItemInstance3D ItemInstance;

        void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<ItemInstance3D>(out var item)) return;
            if(item == ItemInstance) return;
            ItemInstance = item;
            ItemInstance.isInSlot = true;
            ItemInstance.transform.SetParent(transform);
        
            DisplayEnter();
        }

        void OnTriggerStay(Collider other)
        {
            if (ItemInstance == null) return;
            if (ItemInstance.isDragging || !ItemInstance.transform.hasChanged) return;
            OnItemAdded.Invoke(ItemInstance.data,groupId);
            ItemInstance.SetLocalPoseFromData();
            ItemInstance.transform.hasChanged = false;
        }

        void OnTriggerExit(Collider other)
        {
            OnItemRemoved.Invoke(ItemInstance.data,groupId,null);
            ItemInstance.isInSlot = false;
            ItemInstance.transform.SetParent(null);
            highlightRenderer.enabled = false;
            ItemInstance = null;
        }

        void DisplayEnter()
        {
            highlightRenderer.enabled = true;
        
            if (Input.GetKeyDown(KeyCode.Mouse0)) highlightRenderer.material.color = Color.clear;
            else highlightRenderer.material.color = ItemInstance.data.groupIndex == groupId ? m_CorrectSlot : m_IncorrectSlot;
        }

        public override void SyncRemoveItem(ItemData item, int slotId, Pose? pose)
        {
            if (!pose.HasValue) return;
            var value = pose.Value;
            ItemInstance.transform.SetParent(null);
            ItemInstance.transform.SetPositionAndRotation(value.position, value.rotation);
        }
    }
}