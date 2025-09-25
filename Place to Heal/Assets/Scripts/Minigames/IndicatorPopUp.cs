using UnityEngine;

public class IndicatorPopUp : MonoBehaviour
{
    [Header("Character Toggles")]
    public bool Betty;
    public bool Noxya;

    [Header("10 is Max")]
    public byte StressValue = 0; //how low a stat has to get for the to pop up 

    public StatManager statManager;

    [Header("Minigame Indicator")]
    public GameObject indicator;

    void Update()
    {
        if (statManager == null || indicator == null) return;

        if (Betty)
        {
            bool shouldEnable = statManager.Betty_Hunger < StressValue || statManager.Betty_Happiness < StressValue;

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
            bool shouldEnable = statManager.Noxya_Hunger < StressValue || statManager.Noxya_Health < StressValue;

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

