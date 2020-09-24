using UnityEngine;

namespace Server
{
    public interface ICommand
    {
        void Execute();
    }
}