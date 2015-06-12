using UnityEditor;
using UnityEngine;
using System.Collections;

public class AbLoooker : EditorWindow 
{
    [MenuItem("Window/Ab Loooker")]
    private static void Loooker()
    {
        AbLoooker loooker = EditorWindow.GetWindow<AbLoooker>();
        loooker.title = "ab loooker";
        loooker.Show();
    }

    private Object obj;
    private AssetBundleReader abr;

    void OnGUI()
    {
        Object oldObj = obj;
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("拖入检测的assetbundle文件");
        obj = EditorGUILayout.ObjectField(obj, typeof(Object), false);
        EditorGUILayout.EndHorizontal();

        if (obj != null && oldObj != obj)
        {
            string path = AssetDatabase.GetAssetPath(obj);
            path = Application.dataPath + path.Replace("Assets", string.Empty);
            abr = new AssetBundleReader(path);
        }

        GUILayout.Space(16);

        if (abr != null)
        {
            if (abr.header.HasValidSignature())
            {
                GUILayout.Label("not a valid assetbundle file");
            }
            else
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label("");
                GUILayout.EndHorizontal();
            }
        }
    }
}
