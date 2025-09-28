using UnityEngine;

public class PlayBetweenScenes : MonoBehaviour
{
    private static PlayBetweenScenes instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // kill duplicates so the player doesn't cry
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject); 
    }
}

