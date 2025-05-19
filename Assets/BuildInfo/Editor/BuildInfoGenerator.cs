using UnityEditor;

namespace BuildInfo.Editor
{
    public static class BuildInfoGenerator {
        [MenuItem("CI/Set Build Info")]
        public static void SetBuildInfo() {
            var so = AssetDatabase.LoadAssetAtPath<BuildInfo>("Assets/BuildInfo/BuildInfo.asset");
            so.versionSummary = System.Environment.GetEnvironmentVariable("FULL_VERSION_SUMMARY");
            so.versionKey     = System.Environment.GetEnvironmentVariable("FULL_VERSION_KEY");
            PlayerSettings.bundleVersion = so.versionSummary;
            EditorUtility.SetDirty(so);
            AssetDatabase.SaveAssets();
        }
    }
}