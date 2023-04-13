using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class Player : MonoBehaviour
{
    public float speed = 10;
    public float jump = 100;
    float horizontal;
    Rigidbody2D rb;
    public bool triger = true;
    public Text golt;
    public int Score;
    public GameObject point;
    public float radius;
    public LayerMask mask;
    public GameObject particle;
    public bool dest;

    private void Start()
    {
        particle.active = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);
        golt.text = "Gold : " + Score.ToString();

        Collider2D zemin = Physics2D.OverlapCircle(point.transform.position,radius,mask);
        if (zemin == null)
        {
            triger = false;
            transform.parent = null;
            particle.active = false;
        }
        else if(zemin != null && rb.velocity.y<0)
        {
            transform.SetParent(zemin.transform,true);
            particle.active = true;
            StartCoroutine(GamFalse());
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            triger = true;
            speed= 10;
        }
        if (other.gameObject.CompareTag("back"))
        {
            triger = true;
            speed = 0;
        }
    }
    public void JumpButton()
    {
        if (triger)
        {
            rb.AddForce(new Vector3(0, transform.position.y + jump, 0), ForceMode2D.Force);
            triger = false;
        }
    }
    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.white;
        UnityEditor.Handles.DrawWireDisc(point.transform.position,Vector3.back,radius);
    }
    IEnumerator GamFalse()
    {
        yield return new WaitForSeconds(0.5f);
        particle.active = false;
    }
}
