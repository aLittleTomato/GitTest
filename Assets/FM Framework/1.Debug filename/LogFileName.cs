using System.IO;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace FMframework
{
    public class LogFileName : MonoBehaviour
    {
        #if UNITY_EDITOR
        [MenuItem("FMramework/1.导出 unitypackage")]
        #endif
        private static void GenerateUnityPackageName()
        {
            Debug.Log("FMramework_" + DateTime.Now.ToString("yyyyMMdd_hh"));
            string assetPathName = "Assets";
            string fileName = "FMramework_" + DateTime.Now.ToString("yyyyMMdd_hh") + ".unitypackage";
            AssetDatabase.ExportPackage(assetPathName, fileName, ExportPackageOptions.Recurse);
            Application.OpenURL("file:///" + Path.Combine(Application.dataPath, "../"));
        }
    }
}
