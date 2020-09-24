using UnityEngine;

namespace Extras
{
    public static class CameraCastManager
    {
        const int maxCastDistance = 10;
        public static readonly int DefaultMask = LayerMask.GetMask("Default");

        //camera caching because Camera.main is expensive
    
        static Camera _mainCamera;

        [RuntimeInitializeOnLoadMethod]
        public static void Initialise() => _mainCamera = Camera.main;

        public static bool CameraCast(int mask, bool ignoreTriggers, out RaycastHit hit,out Ray ray)
        {
            ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out hit, maxCastDistance, mask,
                ignoreTriggers ? QueryTriggerInteraction.Ignore : QueryTriggerInteraction.Collide);
        }
    }
}