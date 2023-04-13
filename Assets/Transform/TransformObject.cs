using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformObject : MonoBehaviour
{
    public int _moveSpeed;

    private void Update()
    {
        transform.Translate(0,_moveSpeed*Time.deltaTime,0);
    }
}
