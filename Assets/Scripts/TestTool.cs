using System.Linq;
using UnityEditor;
using UnityEngine;

public class TestTool : EditorWindow
{
    /*New Terms/Types
     * GUILayout
     * EditorGUILayout
     * EditorStyles
     * AssetDatabase
     * EditorUtility
     * Selection
     */

    //Refactoring??

    private string upgradeName;
    private string path = $"Assets/SO/Upgrades/";

    [MenuItem("Tools/Upgrade Creator")]
    public static void ShowWindow()
    {
        //GetWindow<TestTool>();
        GetWindow(typeof(TestTool));    
    }
    //When interacting with a window, OnGUI runs
    //Not every frame, but when you interact with the window
    private void OnGUI()
    {
        GUILayout.Label("Look at me, I am a tool!");
        GUILayout.Label("Another text thingy");
        

        GUILayout.Label("I AM A UPGRADE, LOOK AT ME", EditorStyles.boldLabel);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Upgrade name");
        upgradeName = EditorGUILayout.TextField("", upgradeName);

        EditorGUILayout.EndHorizontal();

        if(string.IsNullOrEmpty(upgradeName))
        {
            GUILayout.Label("Please assign a name to your upgrade");
            return;
        }

        if(GUILayout.Button("Create Upgrade"))
        {
            CreateUpgrade();
        }
        //foreach (var item in test)
        //{

        //}
        //Debug.Log(path);

    }
    private void OnEnable()
    {
        //Allocate unmanaged resources or perform one-time set up functions here
        //var names = AssetDatabase.GetAllAssetBundleNames();
        //foreach(var name in names)
        //{
        //    Debug.Log(name);
        //}
        var assets = AssetDatabase.LoadAllAssetRepresentationsAtPath(path);

        string[] cool = AssetDatabase.FindAssets("t:UpgradeSO");

        assets.ToList().ForEach(asset =>
        {
            Debug.Log(asset.name);
        });

        //AssetDatabase.LoadAllAssetsAtPath(path).ToList().ForEach(n => Debug.Log(n));

    }
    private void OnDisable()
    {
        //Free unmanaged resources, state teardown
    }
    private void CreateUpgrade()
    {
        if(CheckUpgradeExists(upgradeName))
        {
            Debug.LogError($"OH OH. You are trying to CREATE SOMETHING THAT ALREADY EXISTS DUMB DUMB {upgradeName} already exists");
            return;
        }

        UpgradeSO upgradeSO = new UpgradeSO();

        //You have to create the asset to make it right
        AssetDatabase.CreateAsset(upgradeSO, $"{path}/{upgradeName}.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = upgradeSO;
    }
    private bool CheckUpgradeExists(string upgradeName)
    {
        return true; //TODO: Add a check somehow
    }
}
