using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void onClickStart()
    {
        SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
    }
}