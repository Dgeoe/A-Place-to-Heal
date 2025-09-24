using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro; 
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("UI References")]
    public GameObject pauseMenuCanvas; 
    public Button resumeButton;
    public Button quitButton;
    public Slider volumeSlider;
    public TMP_Text tipText; 
    public Button pauseButton; 

    [Header("Tips")]
    public string[] tips = new string[4]
    {
        "Do not forget to feed your aliens fruit regularly, or they may grow hungry for something else…",
        "Clean the aliens’ bodies regularly to avoid them growing… unwanted things.",
        "An alien’s happiness is fragile, do not let it grow upset.",
        "Move between their rooms wisely. Some things are best left unseen, but only for a while."
    };

    private bool isPaused = false;
    private int currentTipIndex = 0;

    private void Start()
    {
        // Hide Pause
        if (pauseMenuCanvas != null)
            pauseMenuCanvas.SetActive(false);

        // Buttons
        if (resumeButton != null)
            resumeButton.onClick.AddListener(TogglePause);

        if (quitButton != null)
            quitButton.onClick.AddListener(QuitGame);

        if (pauseButton != null)
            pauseButton.onClick.AddListener(TogglePause);

        
        if (volumeSlider != null)
            volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    private void Update()
    {
        // Tab pause
        if (Keyboard.current != null && Keyboard.current.tabKey.wasPressedThisFrame)
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        if (pauseMenuCanvas != null)
            pauseMenuCanvas.SetActive(isPaused);

        // Freeze time
        Time.timeScale = isPaused ? 0f : 1f;

        // Tips cycle
        if (isPaused)
        {
            ShowNextTip();
        }
    }

    private void ShowNextTip()
    {
        if (tipText != null && tips.Length > 0)
        {
            tipText.text = tips[currentTipIndex];
            currentTipIndex = (currentTipIndex + 1) % tips.Length;
        }
    }

    private void SetVolume(float value)
    {
        
        AudioListener.volume = value;
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
