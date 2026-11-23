
using UnityEngine;
using Vuforia;

public class MonumentTracker : MonoBehaviour
{
    [SerializeField] private NavigationManager manager;
    [SerializeField] private SectionNavigation navigation;
    [SerializeField] private SphereInteraction sphere;

    private ObserverBehaviour observer;

    private void OnEnable()
    {
        observer = GetComponent<ObserverBehaviour>();

        if (observer != null)
            observer.OnTargetStatusChanged += OnStatusChanged;
    }

    private void OnDisable()
    {
        if (observer != null)
            observer.OnTargetStatusChanged -= OnStatusChanged;
    }

    private void OnStatusChanged(
        ObserverBehaviour behaviour,
        TargetStatus status
    )
    {
        if (status.Status == Status.TRACKED ||
            status.Status == Status.EXTENDED_TRACKED)
        {
            manager.SetActiveMonument(navigation, sphere);
        }
    }
}
