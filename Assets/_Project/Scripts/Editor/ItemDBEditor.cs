#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.Linq;

public class ItemDBEditor : EditorWindow
{
    [MenuItem("Tools/Inventory Game/Update Item DB")]
    public static void UpdateItemDB()
    {
        var database = FindDatabase();
        if (database == null)
        {
            Debug.LogError("ItemDB not found in project!");
            return;
        }

        database.Items.Clear();

        string[] guids = AssetDatabase.FindAssets("t:ItemData");
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            ItemData item = AssetDatabase.LoadAssetAtPath<ItemData>(path);
            
            
            if (database.Items.Any(x => x.ID == item.ID))
            {
                Debug.LogError($"Duplicate ID: {item.ID} (Path: {path})");
            }
            else 
            {
                database.Items.Add(item);
            }
            
        }

        EditorUtility.SetDirty(database);
        AssetDatabase.SaveAssets();
        Debug.Log($"Updated ItemDB. Total items: {database.Items.Count}");
    }

    private static ItemDB FindDatabase()
    {
        string[] guids = AssetDatabase.FindAssets("t:ItemDB");
        if (guids.Length == 0) return null;

        string path = AssetDatabase.GUIDToAssetPath(guids[0]);
        return AssetDatabase.LoadAssetAtPath<ItemDB>(path);
    }
}
#endif