using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace BuildInfo
{
    public class BuildInfoUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text versionText;

        private void Start()
        {
            StartCoroutine(InitializeVersion());
        }
        private IEnumerator InitializeVersion()
        {
            var version = "n/a";
            var path = Path.Combine(Application.streamingAssetsPath, "version.txt");

            if (versionText == null)
            {
                Debug.LogWarning("[Build Info] VersionDisplay: versionText não atribuído");
                yield break;
            }

            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                using var www = UnityWebRequest.Get(path);
                yield return www.SendWebRequest();
                if (www.result == UnityWebRequest.Result.Success)
                    version = www.downloadHandler.text.Trim();
                else
                    Debug.LogError($"[Build Info] Ao ler version.txt: {www.error}");
            }

            var lines = content.Split(new[] {'\n','\r'}, System.StringSplitOptions.RemoveEmptyEntries);
            var key = lines.Length > 1 ? lines[1] : lines[0];
            versionText.text = key.Trim();
        }
    }
}
