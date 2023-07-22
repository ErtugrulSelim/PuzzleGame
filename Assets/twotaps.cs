using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class twotaps : MonoBehaviour
{   
    private Rigidbody2D rb;
    private Vector2 vel;
    private bool isCorrect;
    [SerializeField] private TextMeshPro CounterText;

    void Start()
    {
        isCorrect = false;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        CounterText.text = counter.count.ToString();
    }
   
    void FixedUpdate ()
    {
        vel = rb.velocity;
        if (vel.magnitude <= 0.2 && counter.count > 2 && !isCorrect)
        {
            rb.bodyType = RigidbodyType2D.Static;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (counter.count >= 3)
            return;

        if (collision.transform.CompareTag("character"))
        {
            counter.count += 1;
            CounterText.text = counter.count.ToString();
        }

        if (collision.transform.CompareTag("target"))
        {
            collision.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            rb.bodyType = RigidbodyType2D.Static;
            transform.position = collision.transform.position;
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            isCorrect = true;
        }
    }
    
}
