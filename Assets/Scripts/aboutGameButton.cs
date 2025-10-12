using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutProjectButton : MonoBehaviour
{
    public void onClickStart()
    {
        SceneManager.LoadScene("AboutProject", LoadSceneMode.Single);
    }
}