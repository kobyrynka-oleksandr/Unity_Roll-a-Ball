using UnityEngine;
using System;

public static class GameEvents
{
    public static event Action OnPickupCollected;
    public static event Action OnPlayerDied;

    public static void OnPickupCollectedEvent()
    {
        OnPickupCollected?.Invoke();
    }

    public static void OnPlayerDiedEvent()
    {
        OnPlayerDied?.Invoke();
    }
}
