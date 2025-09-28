using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class BrushMiniGame : MonoBehaviour, IPointerEnterHandler
{
    [Header("Audio")]
    public AudioSource snipSound; // sound when snip

    [Header("Mushrooms")]
    public GameObject[] Mushrooms;

    [Header("Brush UI")]
    public RectTransform brushUIObject; // brush that follows mouse
    public Sprite[] brushSprites; // 0 = default, 1 = swapped
    private Image brushUIImage;

    private void Awake()
    {
        if (brushUIObject != null)
            brushUIImage = brushUIObject.GetComponent<Image>();
    }

    public void Reset()
    {
        // Enable all mushrooms again
        foreach (var mushroom in Mushrooms)
        {
            if (mushroom != null)
                mushroom.SetActive(true);
        }

        // Reset brush sprite
        if (brushUIImage != null && brushSprites.Length > 0)
            brushUIImage.sprite = brushSprites[0];
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Collect enabled mushrooms
        var enabledMushrooms = new System.Collections.Generic.List<GameObject>();
        foreach (var mushroom in Mushrooms)
        {
            if (mushroom != null && mushroom.activeSelf)
                enabledMushrooms.Add(mushroom);
        }

        // If no mushrooms left, do nothing
        if (enabledMushrooms.Count == 0)
            return;

        // Pick a random mushroom to disable
        int randIndex = Random.Range(0, enabledMushrooms.Count);
        enabledMushrooms[randIndex].SetActive(false);
        StatManager.Instance.Noxya_Health = Mathf.Min(10, StatManager.Instance.Noxya_Health + 1);

        if (snipSound != null)
            snipSound.Play();

        // Trigger snip animation 
        if (brushUIImage != null && brushSprites.Length > 1)
            StartCoroutine(SwapBrushSprite());
    }

    private IEnumerator SwapBrushSprite()
    {
        brushUIImage.sprite = brushSprites[1]; 
        yield return new WaitForSeconds(1f);
        brushUIImage.sprite = brushSprites[0]; 
    }

    private void Update()
    {
        // Make brush UI follow mouse
        if (brushUIObject != null)
        {
            Vector2 mousePosition = UnityEngine.InputSystem.Mouse.current.position.ReadValue();

            Vector2 uiPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                brushUIObject.parent as RectTransform,
                mousePosition,
                null,
                out uiPosition);

            brushUIObject.localPosition = uiPosition;
        }
    }
}
