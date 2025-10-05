using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text.RegularExpressions;

public class AssetBatchRename : EditorWindow
{
    private string baseName = "Asset";
    private int startNumber = 0;
    private string prefix = "";
    private string suffix = "";
    private string findText = "";
    private string replaceText = "";
    
    [MenuItem("Assets/批量改名工具", false, 20)]
    static void ShowWindow()
    {
        GetWindow<AssetBatchRename>("Asset 批量改名");
    }
    
    void OnGUI()
    {
        GUILayout.Label("Asset 批量改名工具", EditorStyles.boldLabel);
        EditorGUILayout.HelpBox($"当前选中: {Selection.objects.Length} 个资源", MessageType.Info);
        
        GUILayout.Space(10);
        
        // 基础改名
        GUILayout.Label("基础改名", EditorStyles.boldLabel);
        baseName = EditorGUILayout.TextField("基础名称", baseName);
        startNumber = EditorGUILayout.IntField("起始数字", startNumber);
        
        if (GUILayout.Button("重命名为: 名称_数字"))
        {
            BasicRename();
        }
        
        GUILayout.Space(10);
        
        // 前缀后缀
        GUILayout.Label("添加前缀/后缀", EditorStyles.boldLabel);
        prefix = EditorGUILayout.TextField("前缀", prefix);
        suffix = EditorGUILayout.TextField("后缀", suffix);
        
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("添加前缀"))
        {
            AddPrefix();
        }
        if (GUILayout.Button("添加后缀"))
        {
            AddSuffix();
        }
        EditorGUILayout.EndHorizontal();
        
        GUILayout.Space(10);
        
        // 查找替换
        GUILayout.Label("查找替换", EditorStyles.boldLabel);
        findText = EditorGUILayout.TextField("查找", findText);
        replaceText = EditorGUILayout.TextField("替换为", replaceText);
        
        if (GUILayout.Button("执行替换"))
        {
            FindReplace();
        }
        
        GUILayout.Space(10);
        
        // 实用工具
        GUILayout.Label("实用工具", EditorStyles.boldLabel);
        
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("移除数字"))
        {
            RemoveNumbers();
        }
        if (GUILayout.Button("移除空格"))
        {
            RemoveSpaces();
        }
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("转小写"))
        {
            ToLowerCase();
        }
        if (GUILayout.Button("转大写"))
        {
            ToUpperCase();
        }
        EditorGUILayout.EndHorizontal();
    }
    
    void BasicRename()
    {
        Object[] selected = Selection.objects;
        
        if (selected.Length == 0)
        {
            ShowError("请先在 Project 窗口选择要改名的资源");
            return;
        }
        
        for (int i = 0; i < selected.Length; i++)
        {
            string path = AssetDatabase.GetAssetPath(selected[i]);
            string extension = Path.GetExtension(path);
            string newName = $"{baseName}_{startNumber + i}{extension}";
            
            AssetDatabase.RenameAsset(path, Path.GetFileNameWithoutExtension(newName));
        }
        
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log($"已重命名 {selected.Length} 个资源");
    }
    
    void AddPrefix()
    {
        if (string.IsNullOrEmpty(prefix))
        {
            ShowError("请输入前缀");
            return;
        }
        
        Object[] selected = Selection.objects;
        
        foreach (var obj in selected)
        {
            string path = AssetDatabase.GetAssetPath(obj);
            string oldName = Path.GetFileNameWithoutExtension(path);
            string newName = prefix + oldName;
            
            AssetDatabase.RenameAsset(path, newName);
        }
        
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log($"已添加前缀: {selected.Length} 个资源");
    }
    
    void AddSuffix()
    {
        if (string.IsNullOrEmpty(suffix))
        {
            ShowError("请输入后缀");
            return;
        }
        
        Object[] selected = Selection.objects;
        
        foreach (var obj in selected)
        {
            string path = AssetDatabase.GetAssetPath(obj);
            string oldName = Path.GetFileNameWithoutExtension(path);
            string newName = oldName + suffix;
            
            AssetDatabase.RenameAsset(path, newName);
        }
        
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log($"已添加后缀: {selected.Length} 个资源");
    }
    
    void FindReplace()
    {
        if (string.IsNullOrEmpty(findText))
        {
            ShowError("请输入要查找的文本");
            return;
        }
        
        Object[] selected = Selection.objects;
        int count = 0;
        
        foreach (var obj in selected)
        {
            string path = AssetDatabase.GetAssetPath(obj);
            string oldName = Path.GetFileNameWithoutExtension(path);
            
            if (oldName.Contains(findText))
            {
                string newName = oldName.Replace(findText, replaceText);
                AssetDatabase.RenameAsset(path, newName);
                count++;
            }
        }
        
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log($"已替换 {count} 个资源的名称");
    }
    
    void RemoveNumbers()
    {
        Object[] selected = Selection.objects;
        
        foreach (var obj in selected)
        {
            string path = AssetDatabase.GetAssetPath(obj);
            string oldName = Path.GetFileNameWithoutExtension(path);
            string newName = Regex.Replace(oldName, @"[\d_\-\(\)]", "");
            
            if (oldName != newName)
            {
                AssetDatabase.RenameAsset(path, newName);
            }
        }
        
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
    
    void RemoveSpaces()
    {
        Object[] selected = Selection.objects;
        
        foreach (var obj in selected)
        {
            string path = AssetDatabase.GetAssetPath(obj);
            string oldName = Path.GetFileNameWithoutExtension(path);
            string newName = oldName.Replace(" ", "");
            
            if (oldName != newName)
            {
                AssetDatabase.RenameAsset(path, newName);
            }
        }
        
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
    
    void ToLowerCase()
    {
        Object[] selected = Selection.objects;
        
        foreach (var obj in selected)
        {
            string path = AssetDatabase.GetAssetPath(obj);
            string oldName = Path.GetFileNameWithoutExtension(path);
            string newName = oldName.ToLower();
            
            AssetDatabase.RenameAsset(path, newName);
        }
        
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
    
    void ToUpperCase()
    {
        Object[] selected = Selection.objects;
        
        foreach (var obj in selected)
        {
            string path = AssetDatabase.GetAssetPath(obj);
            string oldName = Path.GetFileNameWithoutExtension(path);
            string newName = oldName.ToUpper();
            
            AssetDatabase.RenameAsset(path, newName);
        }
        
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
    
    void ShowError(string message)
    {
        EditorUtility.DisplayDialog("错误", message, "确定");
    }
}