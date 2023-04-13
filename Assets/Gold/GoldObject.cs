using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldObject : MonoBehaviour
{
    public GameObject particle;
    TriggerObject triggerObject;

    private void Start()
    {
        triggerObject = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<TriggerObject>();

        triggerObject.OnGoldTrigger += (gold, skor, ses) => ParticleEffect(gold);
    }

    public void ParticleEffect(GoldObject gold)
    {
        if(gold != this) return;
        Instantiate(particle, transform.position, particle.transform.rotation);
    }
}
