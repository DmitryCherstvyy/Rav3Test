using UnityEngine;

namespace Server
{
    public interface IWebCommand : ICommand
    {
        string url { get; }
        RequestType RequestType { get; }
        WWWForm form { get; }
    }
}