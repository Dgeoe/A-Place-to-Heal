using UnityEngine;

public class FruitPlaceHolder : MonoBehaviour
{
    public Animator BettysReactions;

    public void Feed()
    {
        BettysReactions.SetBool("IsPleased", true);
        StatManager.Instance.Betty_Hunger = Mathf.Min(10, StatManager.Instance.Betty_Hunger + 2);
    }
}
