using UnityEditor;
using UnityEngine;
using System.Collections;

public class Utils : MonoBehaviour 
{
    [MenuItem("Assets/build ab")]
    private static void BuildAb()
    {
        string outputPath = AssetDatabase.GetAssetPath(Selection.activeObject) + ".ab";

        BuildPipeline.BuildAssetBundle(
            Selection.activeObject, 
            null, 
            outputPath, 
            BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.DeterministicAssetBundle | BuildAssetBundleOptions.UncompressedAssetBundle,
            BuildTarget.StandaloneWindows);

        AssetDatabase.Refresh();
    }
}
