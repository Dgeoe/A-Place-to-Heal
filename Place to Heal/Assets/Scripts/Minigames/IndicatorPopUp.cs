using UnityEngine;

public class IndicatorPopUp : MonoBehaviour
{
    [Header("Character Toggles")]
    public bool Betty;
    public bool Noxya;

    [Header("Reference to StatManager")]
    public StatManager statManager;

    [Header("Minigame Indicator GameObject")]
    public GameObject indicator;

    void Update()
    {
        if (statManager == null || indicator == null) return;

        if (Betty)
        {
            bool shouldEnable = statManager.Betty_Hunger < 7 || statManager.Betty_Happiness < 7;

            if (shouldEnable && !indicator.activeSelf)
            {
                indicator.SetActive(true);
            }
            else if (!shouldEnable && indicator.activeSelf)
            {
                indicator.SetActive(false);
            }
        }

        if (Noxya)
        {
            bool shouldEnable = statManager.Noxya_Hunger < 7 || statManager.Noxya_Health < 7;

            if (shouldEnable && !indicator.activeSelf)
            {
                indicator.SetActive(true);
            }
            else if (!shouldEnable && indicator.activeSelf)
            {
                indicator.SetActive(false);
            }
        }
    }
}

