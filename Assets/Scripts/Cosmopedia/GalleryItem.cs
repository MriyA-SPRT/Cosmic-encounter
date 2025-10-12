using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GalleryItem : MonoBehaviour
{
    [Tooltip("Sprite для большой панели. Если не указан — будет взят из Image на этом объекте (thumbnail).")]
    public Sprite bigSprite;

    [TextArea(2, 10)]
    public string description;

    // Если у вас корневой объект грида не определяется автоматически,
    // можно явно указать его тут. Если оставить пустым, скрипт попытается найти
    // ближайший родитель с GridLayoutGroup.
    public Transform groupRoot;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClicked);

        // Попытка автоматически взять спрайт из Image, если bigSprite не задан
        TryAssignSpriteFromImage();

        if (groupRoot == null)
        {
            // пробуем найти ближайший родителя с GridLayoutGroup
            Transform t = transform.parent;
            while (t != null)
            {
                if (t.GetComponent<UnityEngine.UI.GridLayoutGroup>() != null)
                {
                    groupRoot = t;
                    break;
                }
                t = t.parent;
            }

            // если не нашли — просто используем immediate parent
            if (groupRoot == null && transform.parent != null) groupRoot = transform.parent;
        }
    }

    // Работает в редакторе — когда меняете Image или поле в инспекторе, bigSprite подтянется
    private void OnValidate()
    {
        // не выполнять во время playmode изменений
        if (Application.isPlaying) return;

        TryAssignSpriteFromImage();
    }

    private void TryAssignSpriteFromImage()
    {
        if (bigSprite != null) return; // если уже есть — ничего не делаем

        // Пытаемся найти UnityEngine.UI.Image сначала на этом объекте, затем среди дочерних
        Image img = GetComponent<Image>();
        if (img == null) img = GetComponentInChildren<Image>();

        if (img != null && img.sprite != null)
        {
            bigSprite = img.sprite;
        }
        // Если у вас миниатюры — RawImage (Texture), можно преобразовать Texture2D в Sprite,
        // но это уже явное действие и обычно не требуется; напишите, если нужно — добавлю.
    }

    private void OnClicked()
    {
        if (GalleryController.Instance != null)
            GalleryController.Instance.Open(this, groupRoot);
    }

    private void OnDestroy()
    {
        if (_button != null)
            _button.onClick.RemoveListener(OnClicked);
    }
}
