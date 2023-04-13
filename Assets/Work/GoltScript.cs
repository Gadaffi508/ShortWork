using UnityEngine;

public class GoltScript : MonoBehaviour
{
    private SpriteRenderer bg;
    public GameObject particle;

    private void Start()
    {
        bg = GameObject.Find("BackGround").gameObject.GetComponent<SpriteRenderer>();

        GameEvent.currents.onGoldCollected += (x,y) => GoldCollect(x, y);
    }
    private void GoldCollect(GoltScript gold, int Score)
    {
        if (gold != this) return;

        if (Score % 10 == 0 && Score != 0)
        {
            bg.color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f);
        }

        ParticleSpawn();

        Destroy(gold.gameObject);
    }

    private void ParticleSpawn()
    {
        Instantiate(particle, transform.position, Quaternion.identity);
    }
    
}
