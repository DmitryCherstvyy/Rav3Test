using UnityEngine;

[CreateAssetMenu(menuName = "Items/"+nameof(ItemData))]
public class ItemData : ScriptableObject
{
   public int id;
   public new string name;
   public Sprite icon;
    
   public int groupIndex;
   
   public float mouseDragDistance = -0.5f;
   public Pose poseIn3DInventory;
}

