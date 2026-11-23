
using UnityEngine;

public class NavigationManager : MonoBehaviour
{
    private SectionNavigation activeNavigation;
    private SphereInteraction activeSphere;

    public void SetActiveMonument(
        SectionNavigation navigation,
        SphereInteraction sphere
    )
    {
        activeNavigation = navigation;
        activeSphere = sphere;
    }

    public void Navigate(int index)
    {
        if (activeNavigation == null)
            return;

        activeNavigation.ShowSection(index);
    }

    public void Close()
    {
        if (activeSphere == null)
            return;

        activeSphere.CloseContent();
    }
}
