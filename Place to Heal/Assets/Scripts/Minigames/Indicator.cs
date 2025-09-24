using UnityEngine;
using UnityEngine.InputSystem; 

public class Indicator : MonoBehaviour
{
    public GameObject objectToEnable;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject == this.gameObject)
                {
                    if (objectToEnable != null)
                        objectToEnable.SetActive(true);

                    gameObject.SetActive(false);
                }
            }
        }
    }
}


