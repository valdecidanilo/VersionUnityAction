using UnityEngine;

namespace BuildInfo
{
    public class BuildInfoUI : MonoBehaviour
    {
        [SerializeField] private TMPro.TMP_Text versionText;
        [SerializeField] private BuildInfo buildInfo;

        private void Awake()
        {
            if (buildInfo && versionText)
                versionText.text = buildInfo.versionKey;
        }
    }
}
