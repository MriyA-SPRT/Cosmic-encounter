using UnityEngine;

public class CardInCosmopediaScript : MonoBehaviour
{
    private GameObject cardMenu;
    public void OnClick()
    {
        cardMenu.SetActive(true);
    }
    
    public void SetCardMenu(GameObject cardMenu)
    {
        this.cardMenu = cardMenu;
    }
}