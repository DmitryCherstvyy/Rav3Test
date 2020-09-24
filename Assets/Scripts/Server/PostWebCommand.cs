using UnityEngine;
using UnityEngine.Networking;

namespace Server
{
    public struct PostWebCommand : IWebCommand
    {
        public PostWebCommand(string url, WWWForm form)
        {
            this.url = url;
            this.form = form;
        }

        public void Execute() => UnityWebRequest.Post(url, form).SendWebRequest();

        public string url { get; }
        public RequestType RequestType => RequestType.POST;
        public WWWForm form { get; }
    }
}