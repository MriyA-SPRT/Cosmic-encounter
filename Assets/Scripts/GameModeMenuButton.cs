using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeMenuButton : MonoBehaviour
{
    public void onClickStart()
    {
        SceneManager.LoadScene("GameModeSelection", LoadSceneMode.Single);
    }
}
