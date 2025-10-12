using UnityEngine;
using UnityEngine.SceneManagement;

public class cosmopediaButton : MonoBehaviour
{
    public void onClickStart()
    {
        SceneManager.LoadScene("CosmopediaScene", LoadSceneMode.Single);
    }
}
