using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class StartScreenUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image startScreen;
    public Image startScreenHighlighted;
    public Image startScreenBlank;
    public TMP_Text explanationText;

    public float hoverFadeSpeed = 5f;
    public float clickFadeSpeed = 1.5f;
    public float explanationFadeSpeed = 1f;
    public float explanationDuration = 5f;

    public AudioSource hoverAudio;

    private bool isHovered = false;
    private bool clicked = false;

    void Start()
    {
        SetAlpha(startScreenHighlighted, 1f);
        SetAlpha(startScreen, 1f);
        SetAlpha(startScreenBlank, 0f);
        SetAlpha(explanationText, 0f);
    }

    void Update()
    {
        if (clicked) return;
        float targetAlpha = isHovered ? 0f : 1f;
        FadeTo(startScreen, targetAlpha, hoverFadeSpeed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
        if (hoverAudio != null && !hoverAudio.isPlaying)
            hoverAudio.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!clicked)
        {
            clicked = true;
            StartCoroutine(ClickSequence());
        }
    }

    private IEnumerator ClickSequence()
    {
        yield return StartCoroutine(FadeOut(startScreen, clickFadeSpeed));
        yield return StartCoroutine(FadeOut(startScreenHighlighted, clickFadeSpeed));

        yield return new WaitForSeconds(3f);

        yield return StartCoroutine(FadeIn(startScreenBlank, explanationFadeSpeed, explanationText));
        yield return new WaitForSeconds(explanationDuration);
        yield return StartCoroutine(FadeOut(startScreenBlank, explanationFadeSpeed, explanationText));

        SceneManager.LoadScene("Betty_Scene");
    }

    private void SetAlpha(Graphic g, float alpha)
    {
        Color c = g.color;
        c.a = alpha;
        g.color = c;
    }

    private void FadeTo(Graphic g, float target, float speed)
    {
        Color c = g.color;
        c.a = Mathf.MoveTowards(c.a, target, speed * Time.deltaTime);
        g.color = c;
    }

    private IEnumerator FadeIn(Image img, float speed, TMP_Text text = null)
    {
        while (img.color.a < 1f || (text != null && text.color.a < 1f))
        {
            FadeTo(img, 1f, speed);
            if (text != null) FadeTo(text, 1f, speed);
            yield return null;
        }
    }

    private IEnumerator FadeOut(Image img, float speed, TMP_Text text = null)
    {
        while (img.color.a > 0f || (text != null && text.color.a > 0f))
        {
            FadeTo(img, 0f, speed);
            if (text != null) FadeTo(text, 0f, speed);
            yield return null;
        }
    }
}
