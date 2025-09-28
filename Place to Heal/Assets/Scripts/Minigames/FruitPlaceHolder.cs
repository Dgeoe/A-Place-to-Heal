using UnityEngine;
using System.Collections;

public class FruitPlaceHolder : MonoBehaviour
{
    public Animator BettysReactions;
    public BettyBugFace emotes;
    
    public RectTransform uiObject;

    public void Feed()
    {
        BettysReactions.SetBool("IsPleased", true);
        StartCoroutine(FaceTextures(0.5f));
        //StatManager.Instance.Betty_Hunger = Mathf.Min(10, StatManager.Instance.Betty_Hunger + 2);
    }
    private IEnumerator FaceTextures(float value)
    {
        emotes.offset = value;
        yield return new WaitForSeconds(2f);
        emotes.offset = 0f;
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

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
}
