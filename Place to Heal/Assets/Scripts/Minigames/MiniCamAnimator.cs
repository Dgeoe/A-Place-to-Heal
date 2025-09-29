using UnityEngine;

public class MiniCamAnimator : MonoBehaviour
{
    public Animator MiniGameCamera;
    public void isFood()
    {
        MiniGameCamera.SetBool("Food", true);
    }

    public void isWater()
    {
        MiniGameCamera.SetBool("Food", false);
    }
}
