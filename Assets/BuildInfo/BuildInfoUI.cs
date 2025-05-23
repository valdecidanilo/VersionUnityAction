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

        private IEnumerator Start()
        {
            if (versionText == null)
            {
                Debug.LogWarning("[BuildInfoUI] versionText não atribuído");
                yield break;
            }

            string jsonPath = Path.Combine(Application.streamingAssetsPath, "version.json");
            string jsonText;

            if (Application.platform == RuntimePlatform.WebGLPlayer ||
                Application.platform == RuntimePlatform.Android)
            {
                using var www = UnityWebRequest.Get(jsonPath);
                yield return www.SendWebRequest();
                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"[BuildInfoUI] Falha ao ler JSON: {www.error}");
                    yield break;
                }
                jsonText = www.downloadHandler.text;
            }
            else
            {
                try
                {
                    jsonText = File.ReadAllText(jsonPath);
                }
                catch (IOException e)
                {
                    Debug.LogError($"[BuildInfoUI] Erro ao ler JSON: {e.Message}");
                    yield break;
                }
            }

            var data = JsonUtility.FromJson<VersionData>(jsonText);
            versionText.text = data.key;
        }
    }
}
