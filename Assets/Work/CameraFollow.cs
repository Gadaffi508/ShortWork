using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y+2, -10);
    }
}
