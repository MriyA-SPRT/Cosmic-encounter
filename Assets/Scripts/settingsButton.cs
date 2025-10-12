using UnityEngine;
using UnityEngine.SceneManagement;

public class settingsButton : MonoBehaviour
{
    public void onClickStart()
    {
        SceneManager.LoadScene("SettingsScene", LoadSceneMode.Single);
    }
}
