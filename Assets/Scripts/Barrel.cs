using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public float speed = 2.0f; // velocidade do movimento do barril
    //public float ladderChance = 1f; // chance de descer a escada
    private Rigidbody2D rb; // componente Rigidbody2D
    private bool descendingLadder = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // obtém o componente Rigidbody2D
    }

    // Detecta a colisão com a plataforma ou escada
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.AddForce(collision.transform.right * speed, ForceMode2D.Impulse);
            //descendingLadder = false;
        }
    }
}