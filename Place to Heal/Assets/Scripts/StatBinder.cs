using UnityEngine;
using UnityEngine.UI;

public class StatBinder : MonoBehaviour
{
    public StatManager statManager;

    [Header("UI References - Betty")]
    public Image[] bettyUI; // 0 = Hunger, 1 = Health, 2 = Happiness

    [Header("UI References - Noxya")]
    public Image[] noxyaUI; // 0 = Hunger, 1 = Health, 2 = Happiness

    [Header("Game Over UI")]
    public GameObject gameOverUI;
    public Button retryButton;

    private void Awake()
    {
        GameObject smObj = GameObject.Find("StatManager");
        if (smObj != null)
        {
        statManager = smObj.GetComponent<StatManager>();
        }
        if (statManager == null)
        {
            return;
        }

        AssignBettyUI();
        AssignNoxyaUI();
        AssignGameOverUI();
    }

    private void AssignBettyUI()
    {
        if (statManager.Betty_HungerBar == null && bettyUI.Length > 0)
            statManager.Betty_HungerBar = bettyUI[0];

        if (statManager.Betty_HealthBar == null && bettyUI.Length > 1)
            statManager.Betty_HealthBar = bettyUI[1];

        if (statManager.Betty_HappinessBar == null && bettyUI.Length > 2)
            statManager.Betty_HappinessBar = bettyUI[2];
    }

    private void AssignNoxyaUI()
    {
        if (statManager.Noxya_HungerBar == null && noxyaUI.Length > 0)
            statManager.Noxya_HungerBar = noxyaUI[0];

        if (statManager.Noxya_HealthBar == null && noxyaUI.Length > 1)
            statManager.Noxya_HealthBar = noxyaUI[1];

        if (statManager.Noxya_HappinessBar == null && noxyaUI.Length > 2)
            statManager.Noxya_HappinessBar = noxyaUI[2];
    }

    private void AssignGameOverUI()
    {
        if (statManager.GameOverUI == null && gameOverUI != null)
            statManager.GameOverUI = gameOverUI;

        if (statManager.RetryButton == null && retryButton != null)
            statManager.RetryButton = retryButton;
    }
}