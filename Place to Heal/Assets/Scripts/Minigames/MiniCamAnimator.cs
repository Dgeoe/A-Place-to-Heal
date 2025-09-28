using UnityEngine;

public class MiniCamAnimator : MonoBehaviour
{
    public Animator MiniGameCamera;
    public void isFood()
    {
        MiniGameCamera.SetBool("Food", false);
    }

    public void isWater()
    {
        MiniGameCamera.SetBool("Food", true);
    }
}
