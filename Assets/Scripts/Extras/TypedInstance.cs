using UnityEngine;

namespace Extras
{
    public abstract class TypedInstance<T> : MonoBehaviour where T: ScriptableObject
    {
        public T data;
    }
}