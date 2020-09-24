using Extras;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Slots
{
    // ReSharper disable once InconsistentNaming
    public class UISlot : SlotBase , IPointerDownHandler
    {
        [SerializeField] Image iconImage;
        [SerializeField] Text nameText;

        public ItemInstance3D referenceOf3DInstance {private get; set; }

        void Start()
        {
            var dataRef = referenceOf3DInstance?.data;
            if (dataRef && dataRef.icon)
            {
                iconImage.sprite = dataRef.icon;
                iconImage.enabled = true;
                nameText.text = dataRef.name;
            }
        }

        public override void SyncAddItem(ItemData item, int slotId)
        {
            iconImage.sprite = item.icon;
            iconImage.enabled = true;
            nameText.text = item.name;
        }

        public override void SyncRemoveItem(ItemData item, int slotId, Pose? pose)
        {
            iconImage.enabled = false;
            iconImage.sprite = null;
            nameText.text = "";
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            referenceOf3DInstance.transform.SetParent(null);
            
            if (CameraCastManager.CameraCast(CameraCastManager.DefaultMask,true,out var hit,out var ray))
                referenceOf3DInstance.transform.position = hit.point + ray.direction * -0.5f;
            nameText.text = "";
            iconImage.enabled = false;
        }
    }
}
