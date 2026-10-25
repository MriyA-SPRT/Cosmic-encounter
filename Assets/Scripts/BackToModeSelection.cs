using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToModeSelection : MonoBehaviour
{
    public void onClickStart() => SceneManager.LoadScene("GameModeSelection");
}
