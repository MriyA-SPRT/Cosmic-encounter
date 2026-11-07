using UnityEngine;
using UnityEngine.SceneManagement;

public class BotmodeButton : MonoBehaviour
{
    public void onClickStart()
    {
        SceneManager.LoadScene("LocalBotsPlayerCount", LoadSceneMode.Single);
    }
}
