using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class square : MonoBehaviour
{
    public bool pinpong;
    public int a;

    private void Start()
    {
        a = Random.Range(0,2);
    }
    private void Update()
    {
        if (a == 0)
        {
           pinpong = true;
           transform.position = new Vector2(Mathf.PingPong(Time.time, 2), transform.position.y);
        }
        else
        {
           pinpong = false;
        }

    }
}
