using UnityEngine;

namespace BuildInfo
{
    [CreateAssetMenu(fileName = "BuildInfo", menuName = "Build Info")]
    public class BuildInfo : ScriptableObject
    {
        [Header("Resume")] public string versionSummary;
        [HideInInspector] public string versionKey;
    }
}
