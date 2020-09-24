using System.Collections.Generic;
using UnityEngine;

namespace Server
{
    public class ServerCommandManager : MonoBehaviour
    {
        Queue<IWebCommand> WebCommands = new Queue<IWebCommand>();


        static ServerCommandManager instance;

        public static void AddCommand(IWebCommand command)
        {
        
        }
    
        // Update is called once per frame
        void Update()
        {
            foreach (var webCommand in WebCommands)
            {
                webCommand.Execute();
            }
        }
    }
}
