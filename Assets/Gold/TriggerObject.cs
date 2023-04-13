using System;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    PlayerControl playerControl;

    public event Action<GoldObject,int,AudioSource> OnGoldTrigger;

    private void Start()
    {
        playerControl = GetComponent<PlayerControl>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gold"))
        {
            playerControl.transform.localScale = new Vector2(playerControl.transform.localScale.x+0.1f,playerControl.transform.localScale.y + 0.1f);
            playerControl.gold++;

            if (OnGoldTrigger != null)
            {
                OnGoldTrigger(collision.gameObject.GetComponent<GoldObject>(), playerControl.gold, collision.gameObject.GetComponent<AudioSource>());
            }

            Destroy(collision.gameObject);
        }
    }
}
