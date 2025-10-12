using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GalleryController : MonoBehaviour
{
    public static GalleryController Instance { get; private set; }

    [Header("UI Panel (по€вл€етс€ при клике)")]
    public GameObject panel;                 // сама панель (Panel)
    public Image bigImage;                   // UI Image на панели дл€ большого спрайта
    public TMP_Text descriptionText;         // текст описани€ (или UnityEngine.UI.Text если не используете TMP)
    public Button prevButton;
    public Button nextButton;
    public Button backButton;

    [Header("ќпции")]
    public bool wrapAround = true;           // true Ч переход от последней к первой и наоборот

    // внутреннее состо€ние
    private List<GalleryItem> currentItems = new List<GalleryItem>();
    private int currentIndex = 0;
    private Transform currentGroupRoot;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Multiple GalleryController instances found. Destroying duplicate.");
            Destroy(this);
            return;
        }
        Instance = this;

        if (panel != null) panel.SetActive(false);

        // кнопки могут быть назначены в инспекторе Ч добавим на вс€кий случай слушатели
        if (prevButton != null) prevButton.onClick.AddListener(OnPrev);
        if (nextButton != null) nextButton.onClick.AddListener(OnNext);
        if (backButton != null) backButton.onClick.AddListener(Close);
    }

    public void Open(GalleryItem clickedItem, Transform groupRoot)
    {
        if (clickedItem == null) return;

        currentGroupRoot = groupRoot;

        // собираем все GalleryItem в группе (включа€ неактивные если нужно Ч true)
        currentItems = currentGroupRoot.GetComponentsInChildren<GalleryItem>(true).ToList();

        // попытка упор€дочить так, как в Hierarchy Ч GetComponentsInChildren обычно возвращает в пор€дке иерархии
        currentIndex = currentItems.IndexOf(clickedItem);
        if (currentIndex < 0) currentIndex = 0;

        ShowAt(currentIndex);
        if (panel != null) panel.SetActive(true);
    }

    private void ShowAt(int index)
    {
        if (currentItems == null || currentItems.Count == 0) return;
        index = Mathf.Clamp(index, 0, currentItems.Count - 1);
        currentIndex = index;

        GalleryItem item = currentItems[currentIndex];
        if (bigImage != null)
        {
            bigImage.sprite = item.bigSprite;
            bigImage.preserveAspect = true;
        }

        if (descriptionText != null)
            descriptionText.text = item.description ?? "";

        UpdateButtons();
    }

    private void UpdateButtons()
    {
        if (currentItems == null) return;

        if (wrapAround)
        {
            // при wrap Ч кнопки всегда доступны (если больше 1 элемента)
            bool multiple = currentItems.Count > 1;
            if (prevButton != null) prevButton.interactable = multiple;
            if (nextButton != null) nextButton.interactable = multiple;
        }
        else
        {
            if (prevButton != null) prevButton.interactable = currentItems.Count > 0 && currentIndex > 0;
            if (nextButton != null) nextButton.interactable = currentItems.Count > 0 && currentIndex < currentItems.Count - 1;
        }
    }

    public void OnPrev()
    {
        if (currentItems == null || currentItems.Count == 0) return;
        if (wrapAround)
            currentIndex = (currentIndex - 1 + currentItems.Count) % currentItems.Count;
        else
            currentIndex = Mathf.Max(0, currentIndex - 1);

        ShowAt(currentIndex);
    }

    public void OnNext()
    {
        if (currentItems == null || currentItems.Count == 0) return;
        if (wrapAround)
            currentIndex = (currentIndex + 1) % currentItems.Count;
        else
            currentIndex = Mathf.Min(currentItems.Count - 1, currentIndex + 1);

        ShowAt(currentIndex);
    }

    public void Close()
    {
        if (panel != null) panel.SetActive(false);
        currentItems = new List<GalleryItem>();
        currentIndex = 0;
    }

    private void OnDestroy()
    {
        if (prevButton != null) prevButton.onClick.RemoveListener(OnPrev);
        if (nextButton != null) nextButton.onClick.RemoveListener(OnNext);
        if (backButton != null) backButton.onClick.RemoveListener(Close);
    }
}
