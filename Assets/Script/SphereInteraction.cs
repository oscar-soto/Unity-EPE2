
using UnityEngine;
using UnityEngine.EventSystems;

public class SphereInteraction : MonoBehaviour
{
    [SerializeField] private Camera arCamera;
    [SerializeField] private GameObject bridgeCanvas;

    private MeshRenderer sphereRenderer;

    private void Start()
    {
        sphereRenderer = GetComponent<MeshRenderer>();
        bridgeCanvas.SetActive(false);
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                CheckInteraction(touch.position, touch.fingerId);
            }
        }

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            CheckInteraction(Input.mousePosition, -1);
        }
#endif
    }

    private void CheckInteraction(Vector2 position, int pointerId)
    {
        if (EventSystem.current != null &&
            EventSystem.current.IsPointerOverGameObject(pointerId))
        {
            return;
        }

        Ray ray = arCamera.ScreenPointToRay(position);

        if (Physics.Raycast(ray, out RaycastHit hit) &&
            hit.collider.gameObject == gameObject)
        {
            ToggleContent();
        }
    }

    private void ToggleContent()
    {
        bool showContent = !bridgeCanvas.activeSelf;

        bridgeCanvas.SetActive(showContent);
        sphereRenderer.enabled = !showContent;
    }


    public void CloseContent()
    {
        if (!bridgeCanvas.activeSelf)
            return;

        bridgeCanvas.SetActive(false);
        sphereRenderer.enabled = true;
    }

}
