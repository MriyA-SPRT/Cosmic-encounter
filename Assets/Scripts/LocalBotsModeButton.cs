using UnityEngine;
using UnityEngine.SceneManagement;
public class LocalBotsModeButton : MonoBehaviour
{
    public void OpenPlayerCount() => SceneManager.LoadScene("LocalBotsPlayerCount");
}
