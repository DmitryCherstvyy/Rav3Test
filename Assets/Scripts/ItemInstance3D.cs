using System.Threading;
using System.Threading.Tasks;
using Extras;
using UnityEngine;

public class ItemInstance3D : TypedInstance<ItemData>
{
    public bool isInSlot { private get; set; }
    public bool isDragging { get; private set; }
    public new Transform transform { get; private set; }
    public new Rigidbody rigidbody { get; private set; }

    
    /// <summary>
    /// caching some references
    /// </summary>
    void Awake()
    {
        transform = base.transform;
        rigidbody = GetComponent<Rigidbody>();
    }

    
    public void OnMouseDrag()
    {
        isDragging = true;
        if (CameraCastManager.CameraCast(CameraCastManager.DefaultMask,true,out var hit,out var ray));
            transform.position = hit.point + ray.direction * -0.5f;
    }
    void OnMouseUp()
    {
        isDragging = false;
        if(isInSlot) return;
        rigidbody.isKinematic = false;
    }
    void OnMouseDown()
    {
        isDragging = false;
        rigidbody.isKinematic = true;
    }

    
    
    /// <summary>
    /// this calls from Slot,so we set offsets in slot to localPosition and localRotation
    /// </summary>
    public async void SetLocalPoseFromData()
    {
        rigidbody.Sleep();
        transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        return;
        var pose = data.poseIn3DInventory;
        //int timer = 0;
       // int maxTime = 5000;
       if(!Thread.CurrentThread.IsAlive) return;
        var cancellation = new CancellationToken();
        await Task.Run(async () =>
        {
            while (transform.localPosition!=pose.position)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition ,pose.position,0.1f);
                transform.localRotation = Quaternion.RotateTowards(transform.localRotation,pose.rotation,0.1f);
                await Task.Delay(1000,cancellation);
            }
        },cancellation);
    }
}

public class ItemInstance2D : TypedInstance<ItemData>{ }