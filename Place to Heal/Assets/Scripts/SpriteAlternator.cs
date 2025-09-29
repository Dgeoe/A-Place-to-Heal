using UnityEngine;
using UnityEngine.UI;

public class SpriteAlternator : MonoBehaviour
{

    public Image targetImage;
    public Sprite[] sprites;
    public float interval = 2f;

    private int currentIndex = 0;
    private float timer;

    void Start()
    {
        if (sprites.Length == 0 || targetImage == null)
        {
            enabled = false;
            return;
        }

        targetImage.sprite = sprites[currentIndex];
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;
            currentIndex = (currentIndex + 1) % sprites.Length;
            targetImage.sprite = sprites[currentIndex];
        }
    }
}

