using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickIcon : MonoBehaviour
{
    private Image img;
    private bool hasFaded = false;

    void Start()
    {
        img = GetComponent<Image>();

        if (img != null && !hasFaded)
        {
            StartCoroutine(FadeOutAndDisable());
        }
    }

    IEnumerator FadeOutAndDisable()
    {
        hasFaded = true; // make sure this only runs once
        float duration = 6f; 
        float elapsedTime = 0f;

        Color startColor = img.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (elapsedTime < duration)
        {
            img.color = Color.Lerp(startColor, endColor, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        img.color = endColor; 
        gameObject.SetActive(false); 
    }
}
