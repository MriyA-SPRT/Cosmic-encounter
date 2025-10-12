using UnityEngine;
using TMPro;

public class DropdownCardTypes : MonoBehaviour
{
    [SerializeField] private GameObject AliensGrid;
    [SerializeField] private GameObject ContactCardsGrid;
    [SerializeField] private GameObject DestinyGrid;
    [SerializeField] private GameObject FishkiGrid;
    [SerializeField] private GameObject JokersGrid;
    [SerializeField] private GameObject StartCardsGrid;
    [SerializeField] private GameObject TechsGrid;
    public void DropdownSample(int index)
    {
        switch (index)
        {
            case 0:
                AliensGrid.SetActive(true);
                ContactCardsGrid.SetActive(false);
                DestinyGrid.SetActive(false);
                FishkiGrid.SetActive(false);
                JokersGrid.SetActive(false);
                StartCardsGrid.SetActive(false);
                TechsGrid.SetActive(false);
                break;
            case 1:
                AliensGrid.SetActive(false);
                ContactCardsGrid.SetActive(true);
                DestinyGrid.SetActive(false);
                FishkiGrid.SetActive(false);
                JokersGrid.SetActive(false);
                StartCardsGrid.SetActive(false);
                TechsGrid.SetActive(false);
                break;
            case 2:
                AliensGrid.SetActive(false);
                ContactCardsGrid.SetActive(false);
                DestinyGrid.SetActive(true);
                FishkiGrid.SetActive(false);
                JokersGrid.SetActive(false);
                StartCardsGrid.SetActive(false);
                TechsGrid.SetActive(false);
                break;
            case 3:
                AliensGrid.SetActive(false);
                ContactCardsGrid.SetActive(false);
                DestinyGrid.SetActive(false);
                FishkiGrid.SetActive(true);
                JokersGrid.SetActive(false);
                StartCardsGrid.SetActive(false);
                TechsGrid.SetActive(false);
                break;
            case 4:
                AliensGrid.SetActive(false);
                ContactCardsGrid.SetActive(false);
                DestinyGrid.SetActive(false);
                FishkiGrid.SetActive(false);
                JokersGrid.SetActive(true);
                StartCardsGrid.SetActive(false);
                TechsGrid.SetActive(false);
                break;
            case 5:
                AliensGrid.SetActive(false);
                ContactCardsGrid.SetActive(false);
                DestinyGrid.SetActive(false);
                FishkiGrid.SetActive(false);
                JokersGrid.SetActive(false);
                StartCardsGrid.SetActive(true);
                TechsGrid.SetActive(false);
                break;
            case 6:
                AliensGrid.SetActive(false);
                ContactCardsGrid.SetActive(false);
                DestinyGrid.SetActive(false);
                FishkiGrid.SetActive(false);
                JokersGrid.SetActive(false);
                StartCardsGrid.SetActive(false);
                TechsGrid.SetActive(true);
                break;
        }
    }
}
