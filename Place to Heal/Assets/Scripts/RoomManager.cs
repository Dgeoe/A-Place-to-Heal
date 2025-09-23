using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    [Header("Alien GameObjects (for toggling method)")]
    public GameObject BettyObjects;
    public GameObject NoxyaObjects;

    [Header("Room Menu UI")]
    public GameObject roomsMenuPanel; 
    public Button roomsButton;        
    public Button BettyButton;        
    public Button NoxyaButton;        

    private void Start()
    {
        
        if (roomsButton != null)
            roomsButton.onClick.AddListener(ToggleRoomsMenu);

        
        if (BettyButton != null)
            BettyButton.onClick.AddListener(() => SwitchToBetty());

        if (NoxyaButton != null)
            NoxyaButton.onClick.AddListener(() => SwitchToNoxya());

        
        if (roomsMenuPanel != null)
            roomsMenuPanel.SetActive(false);
    }

    private void ToggleRoomsMenu()
    {
        if (roomsMenuPanel != null)
            roomsMenuPanel.SetActive(!roomsMenuPanel.activeSelf);
    }

    private void SwitchToBetty()
    {
        // Close menu
        if (roomsMenuPanel != null)
            roomsMenuPanel.SetActive(false);

        // ----- Toggle GameObjects -----
        if (BettyObjects != null && NoxyaObjects != null)
        {
            BettyObjects.SetActive(true);
            NoxyaObjects.SetActive(false);
        }

        // ........................ Load Scene (if we want) .......................
        // SceneManager.LoadScene("Betty_Scene");
    }

    private void SwitchToNoxya()
    {
        // Close menu
        if (roomsMenuPanel != null)
            roomsMenuPanel.SetActive(false);

        // ----- Toggle GameObjects Method -----
        if (BettyObjects != null && NoxyaObjects != null)
        {
            BettyObjects.SetActive(false);
            NoxyaObjects.SetActive(true);
        }

        // ...................... Load Scene (also if we want) ..........................
        // SceneManager.LoadScene("Noxya_Scene");
    }
}
