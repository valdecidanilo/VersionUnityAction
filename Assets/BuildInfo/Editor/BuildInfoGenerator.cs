using UnityEditor;
using UnityEngine;
using BuildInfo;
namespace BuildInfo.Editor
{
    public static class BuildInfoGenerator
    {
        public static void SetBuildInfo()
        {
            var summary = System.Environment.GetEnvironmentVariable("FULL_VERSION_SUMMARY") ?? "";
            var key     = System.Environment.GetEnvironmentVariable("FULL_VERSION_KEY")     ?? "";

            const string path = "Assets/BuildInfo/BuildInfo.asset";
            var asset = AssetDatabase.LoadAssetAtPath<BuildInfo>(path);
            if (asset == null)
            {
                asset = ScriptableObject.CreateInstance<BuildInfo>();
                AssetDatabase.CreateAsset(asset, path);
            }

            asset.versionSummary = summary;
            asset.versionKey     = key;
            EditorUtility.SetDirty(asset);
            AssetDatabase.SaveAssets();
        }
    }
}