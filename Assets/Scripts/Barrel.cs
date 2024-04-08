using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public float speed = 2.0f; // velocidade do movimento do barril
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // obtém o componente Rigidbody2D
    }

    // Update is called once per frame
    void Update()
    {
        // move o barril horizontalmente
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    // Detecta a colisão com a plataforma
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Colisão com " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Ground"))
        {
            // inverte a direção do movimento do barril
            speed = -speed;
        }
    }
}