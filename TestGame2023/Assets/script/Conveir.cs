using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveir : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

    private void FixedUpdate()
    {
        Vector3 pos = rb.position;
        rb.position += Vector3.left * speed * Time.fixedDeltaTime; 
        rb.MovePosition(pos);
    }
}
