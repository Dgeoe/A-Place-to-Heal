using UnityEngine;

public class RandomSitSetter : MonoBehaviour
{
    [SerializeField] private Animator animator;  
    private const string isSitBool = "isSitBool"; 

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>(); 
        }

        // Randomly choose true or false
        bool randomSit = Random.value > 0.5f;

        // Set the Animator bool
        animator.SetBool(isSitBool, randomSit);
    }
}

