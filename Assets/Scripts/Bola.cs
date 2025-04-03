using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Bola : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool lanzar = true;
    private int vidas = 3;
    private int puntos = 0;

    [SerializeField] private GameObject pala;
    [SerializeField] private TextMeshProUGUI textoVidas;
    [SerializeField] private TextMeshProUGUI textoPuntos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && lanzar && vidas > 0)
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
        if (other.gameObject.CompareTag("ZonaMuerte"))
        {
            ResetearBola();
            vidas--;
            textoVidas.text = "VIDAS: " + vidas.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bloque"))
        {
            Destroy(other.gameObject);
            puntos++;
            textoPuntos.text = "PUNTOS: " + puntos.ToString();
        }
    }

    private void ResetearBola()
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