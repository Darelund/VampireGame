//using System.Linq;
//using UnityEditor;
//using UnityEngine;
//using UnityEngine.UI;

public class UpgradeTool //: //EditorWindow
{
    ////TODO: Come up with a better name
    //public enum AbilityType
    //{
    //    ChangeAbility, //Change a value on an existing class the player has
    //    AddAbility // add a new GameObject to the player
    //}

    ////PlayerWeapon
    ////Stick, sword,
    ////Projectiles(Stones, arrows, magic thingy)

    ///*New Terms/Types
    // * GUILayout
    // * EditorGUILayout
    // * EditorStyles
    // * AssetDatabase
    // * EditorUtility
    // * Selection
    // */

    ////Refactoring??
    //private string path = $"Assets/SO/Upgrades/";


    //private string upgradeName;
    //private string description; //Maybe add a description when you hover over the upgrade
    //private Image image;

    //private AbilityType abilityType;
    //private ChangeAbilityType changeAbilityType;
    //private GameObject prefab;


    //[MenuItem("Tools/Upgrade Creator")]
    //public static void ShowWindow()
    //{
    //    //GetWindow<TestTool>();
    //    GetWindow(typeof(UpgradeTool));    
    //}
    ////When interacting with a window, OnGUI runs
    ////Not every frame, but when you interact with the window
    //private void OnGUI()
    //{
    //    //GUILayout.Label("Look at me, I am a tool!");
    //    //GUILayout.BeginHorizontal();
    //    //GUILayout.Label("Look at me, sssss!");
    //    //GUILayout.TextField("Description"); GUILayout.EndHorizontal();
    //    //GUILayout.EndHorizontal();


    //    GUILayout.Label("Create Upgrade", EditorStyles.boldLabel);

    //    //------------------------------- Give name ---------------------------------------
    //    EditorGUILayout.BeginHorizontal();
    //    GUILayout.Label("Name");
    //    upgradeName = EditorGUILayout.TextField("", upgradeName);
    //    EditorGUILayout.EndHorizontal();

    //    if (string.IsNullOrEmpty(upgradeName))
    //    {
    //        GUILayout.Label("Please assign a name to your upgrade");
    //        //   return;
    //    }


    //    //------------------------------- Give Description ---------------------------------------
    //    EditorGUILayout.BeginHorizontal();
    //    GUILayout.Label("Description");
    //    description = EditorGUILayout.TextArea("", description);
    //    EditorGUILayout.EndHorizontal();

    //    if (string.IsNullOrEmpty(description))
    //    {
    //        GUILayout.Label("Please assign a description to your upgrade");
    //        //  return;
    //    }



    //    //------------------------------- Give Image ---------------------------------------
    //    //EditorGUILayout.BeginHorizontal();
    //    //GUILayout.Label("Image");
    //    // image = EditorGUILayout.
    //    //EditorGUILayout.EndHorizontal();

    //    if (string.IsNullOrEmpty(description))
    //    {
    //        GUILayout.Label("Please assign a description to your upgrade");
    //        //  return;
    //    }




    //    if (GUILayout.Button("Create Upgrade"))
    //    {
    //        CreateUpgrade();
    //    }
    //    //foreach (var item in test)
    //    //{

    //    //}
    //    //Debug.Log(path);

    //}
    //private void OnEnable()
    //{
    //    //Allocate unmanaged resources or perform one-time set up functions here
    //    //var names = AssetDatabase.GetAllAssetBundleNames();
    //    //foreach(var name in names)
    //    //{
    //    //    Debug.Log(name);
    //    //}
    //    var assets = AssetDatabase.LoadAllAssetRepresentationsAtPath(path);

    //    string[] cool = AssetDatabase.FindAssets("t:UpgradeSO");

    //    assets.ToList().ForEach(asset =>
    //    {
    //        Debug.Log(asset.name);
    //    });

    //    //AssetDatabase.LoadAllAssetsAtPath(path).ToList().ForEach(n => Debug.Log(n));

    //}
    //private void OnDisable()
    //{
    //    //Free unmanaged resources, state teardown
    //}
    //private void CreateUpgrade()
    //{
    //    if(CheckUpgradeExists(upgradeName))
    //    {
    //        Debug.LogError($"OH OH. You are trying to CREATE SOMETHING THAT ALREADY EXISTS DUMB DUMB {upgradeName} already exists");
    //        return;
    //    }

    //    //UpgradeSO upgradeSO = new UpgradeSO();

    //    ////You have to create the asset to make it right
    //    //AssetDatabase.CreateAsset(upgradeSO, $"{path}/{upgradeName}.asset");
    //    //AssetDatabase.SaveAssets();
    //    //AssetDatabase.Refresh();
    //    //EditorUtility.FocusProjectWindow();
    //    //Selection.activeObject = upgradeSO;
    //}
    //private bool CheckUpgradeExists(string upgradeName)
    //{
    //    return true; //TODO: Add a check somehow
    //}
}
