using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triger : MonoBehaviour
{
    Player player;
    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("gold"))
        {
            player.Score++;

            GoltScript gold = other.gameObject.GetComponent<GoltScript>();
            GameEvent.currents.EventHelper(gold, player.Score);
        }
    }
}
