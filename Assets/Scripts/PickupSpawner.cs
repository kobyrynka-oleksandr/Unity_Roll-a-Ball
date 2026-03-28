using UnityEngine;
using System.Collections.Generic;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private Pickup[] allPickups;

    private int activePickupIndex = -1;

    public void SpawnNextPickup()
    {
        SpawnNextRandom();
    }

    public void OnPickupCollected()
    {
        if (activePickupIndex >= 0)
            allPickups[activePickupIndex].gameObject.SetActive(false);

        SpawnNextRandom();
    }

    private void SpawnNextRandom()
    {
        if (allPickups.Length == 0) return;

        List<int> candidates = new List<int>();
        for (int i = 0; i < allPickups.Length; i++)
        {
            if (i != activePickupIndex)
                candidates.Add(i);
        }

        if (candidates.Count == 0)
            candidates.Add(activePickupIndex);

        int randomIndex = candidates[Random.Range(0, candidates.Count)];
        activePickupIndex = randomIndex;
        allPickups[activePickupIndex].gameObject.SetActive(true);
    }

    public void ResetAndSpawn()
    {
        foreach (var pickup in allPickups)
            pickup.gameObject.SetActive(false);

        activePickupIndex = -1;
        SpawnNextRandom();
    }
}