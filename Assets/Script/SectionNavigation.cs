
using UnityEngine;

public class SectionNavigation : MonoBehaviour
{
    [SerializeField] private GameObject[] sections;

    private int currentIndex = 0;

    private void Start()
    {
        ShowSection(0);
    }

    public void ShowSection(int index)
    {
        if (index < 0 || index >= sections.Length)
            return;

        currentIndex = index;

        for (int i = 0; i < sections.Length; i++)
        {
            sections[i].SetActive(i == currentIndex);
        }
    }
}
