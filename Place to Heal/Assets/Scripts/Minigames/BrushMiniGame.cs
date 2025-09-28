using UnityEngine;
using UnityEngine.EventSystems; 
using TMPro;

public class BrushMiniGame : MonoBehaviour, IPointerEnterHandler
{
    public int snips = 0;
    public TMP_Text snipsText;

    private void Start()
    {
        UpdateUI();
    }

    //when pass over = increment 
    public void OnPointerEnter(PointerEventData eventData)
    {
        snips++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (snipsText != null)
            snipsText.text = snips.ToString();
    }
}
