using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameEvent : MonoBehaviour
{ //biraz çorba olmuþ ortalýk ^^  ben yaptým ya :D

    public static GameEvent currents;
    private void Awake()
    {
        currents = this;
    }


    public event Action<GoltScript, int> onGoldCollected;

    public void EventHelper(GoltScript triggerGold, int Score)
    {
        if(onGoldCollected != null)
            onGoldCollected(triggerGold, Score);
    }
}
