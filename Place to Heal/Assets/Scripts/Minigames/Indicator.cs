using UnityEngine;
using UnityEngine.InputSystem; 

public class Indicator : MonoBehaviour
{
    public GameObject objectToEnable;
    public GameObject pause;
    public GameObject rooms;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject self; //idk why gameObject.SetActive(false); isnt working atm smh on god
    public GameObject backbutton;
    public GameObject FoodButton;
    public GameObject WaterButton;


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
                        pause.SetActive(false);
                        rooms.SetActive(false);
                        camera1.SetActive(false);
                        camera2.SetActive(true);
                        backbutton.SetActive(true);
                        FoodButton.SetActive(true);
                        WaterButton.SetActive(true);
                        self.SetActive(false); 

                }
            }
        }
    }
}


