using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();

    }
    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.transform.CompareTag("target"))
        {
            collision.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            rb.bodyType = RigidbodyType2D.Static;
            transform.position = collision.transform.position;
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
