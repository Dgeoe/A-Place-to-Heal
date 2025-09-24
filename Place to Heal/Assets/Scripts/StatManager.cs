using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class StatManager : MonoBehaviour
{
    public static StatManager Instance;

    [Header("Betty Stats")]
    public int Betty_Hunger = 10;
    public int Betty_Health = 10;
    public int Betty_Happiness = 10;

    [Header("Noxya Stats")]
    public int Noxya_Hunger = 10;
    public int Noxya_Health = 10;
    public int Noxya_Happiness = 10;

    [Header("UI References - Betty")]
    public Image Betty_HungerBar;
    public Image Betty_HealthBar;
    public Image Betty_HappinessBar;

    [Header("UI References - Noxya")]
    public Image Noxya_HungerBar;
    public Image Noxya_HealthBar;
    public Image Noxya_HappinessBar;

    [Header("Drain Settings (seconds per point)")]
    public float hungerDrainInterval = 30f;
    public float healthDrainInterval = 30f;
    public float happinessDrainInterval = 30f;

    [Header("Game Over UI")]
    public GameObject GameOverUI;
    public Button RetryButton;

    // Timers
    private float bettyHungerTimer = 0f;
    private float bettyHealthTimer = 0f;
    private float bettyHappinessTimer = 0f;

    private float noxyaHungerTimer = 0f;
    private float noxyaHealthTimer = 0f;
    private float noxyaHappinessTimer = 0f;

    private bool isGameOver = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Retry Button
        if (RetryButton != null)
            RetryButton.onClick.AddListener(RestartGame);

        if (GameOverUI != null)
            GameOverUI.SetActive(false);
    }

    private void Update()
    {
        if (isGameOver) return;

        float delta = Time.deltaTime;

        
        UpdateUI();

        DrainStat(ref Betty_Hunger, ref bettyHungerTimer, hungerDrainInterval);
        DrainStat(ref Betty_Health, ref bettyHealthTimer, healthDrainInterval);
        DrainHappiness(ref Betty_Happiness, ref bettyHappinessTimer, Betty_Hunger, Betty_Health);

        DrainStat(ref Noxya_Hunger, ref noxyaHungerTimer, hungerDrainInterval);
        DrainStat(ref Noxya_Health, ref noxyaHealthTimer, healthDrainInterval);
        DrainHappiness(ref Noxya_Happiness, ref noxyaHappinessTimer, Noxya_Hunger, Noxya_Health);

        CheckKeyCombos();

        
        if (Betty_Happiness <= 0 || Noxya_Happiness <= 0)
        {
            TriggerGameOver();
        }
    }

    private void UpdateUI()
    {
        // Betty
        if (Betty_HungerBar != null)
            Betty_HungerBar.fillAmount = Mathf.Clamp01(Betty_Hunger / 10f);
        if (Betty_HealthBar != null)
            Betty_HealthBar.fillAmount = Mathf.Clamp01(Betty_Health / 10f);
        if (Betty_HappinessBar != null)
            Betty_HappinessBar.fillAmount = Mathf.Clamp01(Betty_Happiness / 10f);

        // Noxya
        if (Noxya_HungerBar != null)
            Noxya_HungerBar.fillAmount = Mathf.Clamp01(Noxya_Hunger / 10f);
        if (Noxya_HealthBar != null)
            Noxya_HealthBar.fillAmount = Mathf.Clamp01(Noxya_Health / 10f);
        if (Noxya_HappinessBar != null)
            Noxya_HappinessBar.fillAmount = Mathf.Clamp01(Noxya_Happiness / 10f);
    }

    private void DrainStat(ref int stat, ref float timer, float interval)
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            stat = Mathf.Max(0, stat - 1);
            timer = 0f;
        }
    }

    private void DrainHappiness(ref int happiness, ref float timer, int hunger, int health)
    {
        if (hunger == 0 || health == 0)
        {
            timer += Time.deltaTime;
            float interval = (hunger == 0 && health == 0) ? happinessDrainInterval / 2f : happinessDrainInterval;
            if (timer >= interval)
            {
                happiness = Mathf.Max(0, happiness - 1);
                timer = 0f;
            }
        }
        else
        {
            timer = 0f;
        }
    }

    private void CheckKeyCombos()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        // Betty Feed (B + F)
        if (keyboard.bKey.isPressed && keyboard.fKey.wasPressedThisFrame)
            Betty_Hunger = Mathf.Min(10, Betty_Hunger + 2);

        // Betty Clean (B + C)
        if (keyboard.bKey.isPressed && keyboard.cKey.wasPressedThisFrame)
            Betty_Health = Mathf.Min(10, Betty_Health + 2);

        // Noxya Feed (N + F)
        if (keyboard.nKey.isPressed && keyboard.fKey.wasPressedThisFrame)
            Noxya_Hunger = Mathf.Min(10, Noxya_Hunger + 2);

        // Noxya Clean (N + C)
        if (keyboard.nKey.isPressed && keyboard.cKey.wasPressedThisFrame)
            Noxya_Health = Mathf.Min(10, Noxya_Health + 2);
    }

    private void TriggerGameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;

        if (GameOverUI != null)
            GameOverUI.SetActive(true);
    }

    private void RestartGame()
    {
        // Reset stats
        Betty_Hunger = 10;
        Betty_Health = 10;
        Betty_Happiness = 10;

        Noxya_Hunger = 10;
        Noxya_Health = 10;
        Noxya_Happiness = 10;

        // Reset timer
        bettyHungerTimer = bettyHealthTimer = bettyHappinessTimer = 0f;
        noxyaHungerTimer = noxyaHealthTimer = noxyaHappinessTimer = 0f;

        // Hide Game Over
        if (GameOverUI != null)
            GameOverUI.SetActive(false);

        isGameOver = false;
        Time.timeScale = 1f; // Resume game
    }
}
