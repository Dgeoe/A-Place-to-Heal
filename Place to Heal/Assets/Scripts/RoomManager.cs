using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    public RectTransform roomsMenuPanel;
    public Button roomsButton;
    public Button BettyButton;
    public Button NoxyaButton;

    public float slideDistance = 200f;
    public float slideSpeed = 5f;

    private Vector2 originalPosition;
    private Vector2 targetPosition;
    private bool isMenuOpen = false;

    private void Start()
    {
        if (roomsButton != null)
            roomsButton.onClick.AddListener(ToggleRoomsMenu);

        if (BettyButton != null)
            BettyButton.onClick.AddListener(() => SwitchToBetty());

        if (NoxyaButton != null)
            NoxyaButton.onClick.AddListener(() => SwitchToNoxya());

        if (roomsMenuPanel != null)
        {
            originalPosition = roomsMenuPanel.anchoredPosition;
            targetPosition = originalPosition;
        }
    }

    private void Update()
    {
        if (roomsMenuPanel != null)
        {
            roomsMenuPanel.anchoredPosition = Vector2.Lerp(
                roomsMenuPanel.anchoredPosition,
                targetPosition,
                Time.deltaTime * slideSpeed
            );
        }
    }

    private void ToggleRoomsMenu()
    {
        if (roomsMenuPanel == null) return;

        if (!isMenuOpen)
            targetPosition = originalPosition + Vector2.left * slideDistance;
        else
            targetPosition = originalPosition;

        isMenuOpen = !isMenuOpen;
    }

    private void SwitchToBetty()
    {
        Debug.Log("Switching to Betty_Scene.");
        CloseMenu();
        SceneManager.LoadScene("Betty_Scene");
    }

    private void SwitchToNoxya()
    {
        Debug.Log("Switching to Noxya_Scene.");
        CloseMenu();
        SceneManager.LoadScene("Noxya_Scene");
    }

    private void CloseMenu()
    {
        if (roomsMenuPanel != null)
            targetPosition = originalPosition;

        isMenuOpen = false;
    }
}
