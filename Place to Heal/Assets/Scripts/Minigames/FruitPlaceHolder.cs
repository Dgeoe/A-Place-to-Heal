using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.UI; 

public class FruitPlaceHolder : MonoBehaviour
{
    public Animator BettysReactions;
    public BettyBugFace emotes;
    public RectTransform uiObject;

    [Header("Sprite Swapping")]
    public Sprite[] sprites; //0= full, 1= bitten 
    private Image uiImage;   

    private void Awake()
    {
        uiImage = uiObject.GetComponent<Image>();
    }

    public void Feed() 
    {
        if (uiImage.sprite == sprites[0])
        {
            BettysReactions.SetBool("IsPleased", true);
            StartCoroutine(FaceTextures(0.5f));
            uiImage.sprite = sprites[1];
            StatManager.Instance.Betty_Hunger = Mathf.Min(10, StatManager.Instance.Betty_Hunger + 2);
        }
    }

    private IEnumerator FaceTextures(float value)
    {
        emotes.offset = value;
        yield return new WaitForSeconds(2f);
        emotes.offset = 0f;
    }

    void Update()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        if (mousePosition.x > Screen.width / 2f)
        {
            Vector2 uiPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                uiObject.parent as RectTransform,
                mousePosition,
                null,
                out uiPosition);

            uiObject.localPosition = uiPosition;
        }
    }

    public void SwapSprite()
    {
        uiImage.sprite = sprites[0];
    }
}