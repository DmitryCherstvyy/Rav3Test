using UnityEngine;
using UnityEngine.Events;

namespace Extras
{
    public class MouseEnterExitTrigger : MonoBehaviour
    {
        [SerializeField] KeyCode detectIntersectionOnThisKey = KeyCode.Mouse0;

        [SerializeField] UnityEvent onMouseEnterCollider;
        [SerializeField] UnityEvent onMouseExitCollider;
    
        Collider m_Collider;
        void Awake()
        {
            m_Collider = GetComponent<Collider>();
        }

        void Update()
        {
            if (!Input.GetKey(detectIntersectionOnThisKey)) return;
            if (!CameraCastManager.CameraCast(CameraCastManager.DefaultMask,true,out var hit,out _)) return;
        
            if (m_Collider.ClosestPoint(hit.point) == hit.point)
                onMouseEnterCollider.Invoke();
            else
                onMouseExitCollider.Invoke();
        }
    }
}