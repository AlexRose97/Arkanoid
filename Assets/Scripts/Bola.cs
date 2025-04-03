using System;
using Unity.VisualScripting;
using UnityEngine;

public class Bola : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject pala;

    private bool lanzar = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && lanzar)
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
            lanzar = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ResetearBola();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bloque"))
        {
            Destroy(other.gameObject);
        }
    }

    private void ResetearBola()
    {
        if (other.gameObject.CompareTag("ZonaMuerte"))
        {
            /*
             * 0. se frena la velocidad
             * 1. se cambia el tipo de movimiento
             * 2. Se vincula con la pala(jugador)
             * 3. se coloca en el origen la bola.
             */
            rb.linearVelocity = Vector2.zero;
            rb.isKinematic = true;
            transform.SetParent(pala.transform);
            transform.localPosition = new Vector3(0, 1, 0);
            lanzar = true;
        }
    }
}