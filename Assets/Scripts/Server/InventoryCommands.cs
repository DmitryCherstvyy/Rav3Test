using UnityEngine;

namespace Server
{
    public struct InventoryCommands
    {
        const string url = "https://dev3r02.elysium.today/inventory/status";
        const string authKey = "BMeHG5xqJeB4qCjpuJCTQLsqNGaqkfB6";
    
        /// <summary>
        /// cached GetItems from server command that calls on game start
        /// </summary>
        public static readonly IWebCommand GetItemFromServerCommand = new PostWebCommand(url,new WWWForm()
        {
            headers =
            {
                { "auth", authKey},
                { "eventId",nameof(GetItemFromServerCommand).GetHashCode().ToString()}
            },
        });

        /// <summary>
        /// cached hash of add command
        /// </summary>
        static readonly string AddItemCommandHash = nameof(AddItemFromServerCommand).GetHashCode().ToString();
    
        /// <summary>
        /// Calls when Item was added to inventory
        /// </summary>
        /// <param name="itemId">Id of Added item</param>
        public static IWebCommand AddItemFromServerCommand(int itemId) => new PostWebCommand(url,new WWWForm()
        {
            headers =
            {
                {"auth", authKey },
                {"eventId",RemoveItemCommandHash},
                {"itemId", itemId.ToString()}
            },
        });
    
    
        /// <summary>
        /// cached hash of remove command
        /// </summary>
        static readonly string RemoveItemCommandHash = nameof(RemoveItemFromServerCommand).GetHashCode().ToString();
    
        /// <summary>
        /// Calls when Item was removed from inventory
        /// </summary>
        /// <param name="itemId">Id of Added item</param>
        public static IWebCommand RemoveItemFromServerCommand(int itemId) => new PostWebCommand(url,new WWWForm()
        {
            headers =
            {
                {"auth", authKey },
                {"eventId",RemoveItemCommandHash},
                {"itemId", itemId.ToString()}
            },
        });
    }
}
