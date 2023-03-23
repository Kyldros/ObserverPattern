using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementManager : MonoBehaviour, iObserver
{
    private bool collectorGained;
    public void OnPlayerScoreChanged(int newScore)
    {
        if (!collectorGained && newScore >= 5)
        {
            Debug.Log("Hai raggiunto 5 monete!");
            collectorGained = true;
        }
            
    }

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        Player player = playerObject.GetComponent<Player>();

        player.AddObserver(this);
    }
}
