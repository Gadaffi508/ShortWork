using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameEvent : MonoBehaviour
{ //biraz �orba olmu� ortal�k ^^  ben yapt�m ya :D

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
