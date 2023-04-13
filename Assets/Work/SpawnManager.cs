using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Zemin")]
    public GameObject spawnlanacakZemin;
    public GameObject sonZemin;             //Baslangic olarak zemini secip ustune ýnsaa ediyoruz

    [Header("Gold")]
    public GameObject gold;
    public GameObject sonGold;

    [Header("Islemler")]
    public int zeminsayýsý;
    public Vector3 spankonum;
    public Transform player;

    private void Start()
    {
        StartingSpawns();
    }
    private void FixedUpdate()
    {
        float distanceZemin = Vector3.Distance(player.transform.position, sonZemin.transform.position); //Son obje ile aradaki mesafe
        if(distanceZemin < 10)
        {
            sonZemin = YeniZemin();
            sonGold = YeniGold();
        }
    }
    public void StartingSpawns()
    {
        for (int i = 0; i < zeminsayýsý; i++)
        {              
            sonZemin = YeniZemin();     //i arttikca spawnlanan yeni zemini son zemine esitliyoruz
            sonGold = YeniGold();
        }
    }

    private Vector3 YeniKonum(float spawnlananobjeY)     //spawnlanacak konum, obje spawnlanmadan once yeni konumu son objeye gore belirleniyor
    {
        spankonum = new Vector3(Random.Range(-2, 2),
                spawnlananobjeY + 2,
                0);
        return spankonum;
    }

    private GameObject YeniGold()
    {
        YeniKonum(sonGold != null ? sonGold.transform.position.y : 1); //Basta songold degiskeni bos olacagi icin bos ise yeni konumun y pozisyonu 1 veriyoruz
        return Instantiate(gold, new Vector2(spankonum.x, spankonum.y), Quaternion.identity);
    }

    private GameObject YeniZemin()
    {
        YeniKonum(sonZemin.transform.position.y);
        return Instantiate(spawnlanacakZemin, spankonum, Quaternion.identity);
    }
}
