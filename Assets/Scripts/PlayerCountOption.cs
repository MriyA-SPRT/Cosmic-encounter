using UnityEngine;
using UnityEngine.UI;
public class PlayerCountOption : MonoBehaviour
{
    public int playerCount = 3;
    private static readonly System.Collections.Generic.List<PlayerCountOption> Options = new();
    private Image image;
    private void OnEnable()
    {
        image = GetComponent<Image>();
        if (!Options.Contains(this)) Options.Add(this);
        RefreshAll();
    }
    private void OnDisable() { Options.Remove(this); }
    public void Select()
    {
        PlayerPrefs.SetInt("LocalBotsPlayerCount", Mathf.Clamp(playerCount, 3, 8));
        PlayerPrefs.Save();
        RefreshAll();
    }
    private static void RefreshAll()
    {
        int selected = PlayerPrefs.GetInt("LocalBotsPlayerCount", 3);
        foreach (var option in Options)
            if (option != null && option.image != null)
                option.image.color = option.playerCount == selected ? new Color(0.68f, 0.92f, 1f) : Color.white;
    }
}
