using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voice : MonoBehaviour
{
    TriggerObject triggerObject;

    public AudioSource Ses;

    private void Start()
    {
        triggerObject = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<TriggerObject>();

        triggerObject.OnGoldTrigger += (gold, skor, ses) => SoundEffect();
    }
    public void SoundEffect()
    {
        if (Ses != null)
        {
            Ses.Stop();
            Ses.Play();
        }
    }
}
