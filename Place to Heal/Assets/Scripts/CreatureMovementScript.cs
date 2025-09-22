using UnityEngine;

public class CreatureMovementScript : MonoBehaviour
{
    public Transform[] spawnPositions;

    //Rotation Corrections
    public float[] spawnYRotations;

    // Stores the last used position index so each creature is never in the same place when revisting scenes
    private const string LastPositionKey = "CreatureLastPositionIndex";

    void Start()
    {
        if (spawnPositions == null || spawnPositions.Length == 0)
        {
            Debug.LogWarning("No Spawn Positions Set");
            return;
        }

        if (spawnYRotations == null || spawnYRotations.Length != spawnPositions.Length)
        {
            Debug.LogWarning("spawnYRotations must be the same length as spawnPositions.");
            return;
        }

        int lastIndex = PlayerPrefs.GetInt(LastPositionKey, -1); 

        // Choose a new (from last time visiting) random pos (onlyif possible)
        int newIndex = GetRandomIndexExcluding(spawnPositions.Length, lastIndex);
        transform.position = spawnPositions[newIndex].position;
        transform.rotation = Quaternion.Euler(0f, spawnYRotations[newIndex], 0f);

        // Store the pos for next time
        PlayerPrefs.SetInt(LastPositionKey, newIndex);
        PlayerPrefs.Save(); 
    }

    private int GetRandomIndexExcluding(int length, int excludeIndex)
    {
        if (length <= 1)
            return 0; 

        int index;
        do
        {
            index = Random.Range(0, length);
        } while (index == excludeIndex);

        return index;
    }
}

