using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/"+nameof(ItemGroupsStorage),fileName = nameof(ItemGroupsStorage))]
public class ItemGroupsStorage : ScriptableObject
{
    [SerializeField] int[] groupsIds;
    [SerializeField] string[] groupsNames;
    
    /// <summary>
    /// we use Dictionary boost the searching performance
    /// </summary>
    static Dictionary<int, string> _groupsCollection;

    public static string GetGroupNameById(int groupId)
    {
        if(_groupsCollection == null) 
            LoadStaticInstanceAndCreateDictionary();
        
        // ReSharper disable once PossibleNullReferenceException
        if (_groupsCollection.TryGetValue(groupId, out string result))
            return result;
        throw new NotImplementedException($"Group with Id:{groupId} not implemented");
    }
    
    public static ICollection<string> GetAllGroupsNames()
    {
        if(_groupsCollection == null) 
            LoadStaticInstanceAndCreateDictionary();
        
        // ReSharper disable once PossibleNullReferenceException
        if (_groupsCollection.Count > 0)
            return _groupsCollection.Values;
        throw new NotImplementedException($"Groups not implemented");
    }

    /// <summary>
    /// here is instance loading and
    /// we make Dictionary here to boost the searching performance then
    /// </summary>
    static void LoadStaticInstanceAndCreateDictionary()
    {
        var instance = Resources.Load<ItemGroupsStorage>(nameof(ItemGroupsStorage));
        ref var groupsIds = ref instance.groupsIds;
        ref var groupsNames = ref instance.groupsNames;
        
        int targetCount = groupsIds.Length;
        
        _groupsCollection = new Dictionary<int, string>(targetCount);
        for (int i = 0; i < targetCount; i++) 
            _groupsCollection.Add(groupsIds[i], groupsNames[i]);
    }
}