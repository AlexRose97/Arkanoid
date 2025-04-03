using System;
using Unity.VisualScripting;
using UnityEngine;

public class Bola : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*
             * 1. se desvincula de la barra del jugador
             * 2. se agrega movimiento dinamico y se elimina la gravedad
             * 3. se agrega fuerza de impulso
             */
            transform.SetParent(null);
            rb.isKinematic = false;
            rb.gravityScale = 0;
            rb.AddForce(new Vector2(1, 1).normalized * 10, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bloque"))
        {
            Destroy(other.gameObject);
        }
    }
}