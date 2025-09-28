using UnityEngine;
using UnityEngine.InputSystem;

public class MouseClick : MonoBehaviour
{
    public AudioSource clickAudio;

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (clickAudio != null)
                clickAudio.Play();
        }
    }
}
