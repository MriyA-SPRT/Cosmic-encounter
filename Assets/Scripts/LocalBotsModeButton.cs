using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LocalBotsModeButton : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OpenPlayerCount);
    }

    private void OnDestroy()
    {
        if (button != null)
            button.onClick.RemoveListener(OpenPlayerCount);
    }

    public void OpenPlayerCount()
    {
        SceneManager.LoadScene("LocalBotsPlayerCount", LoadSceneMode.Single);
    }
}
