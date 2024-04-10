using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public float speed = 2.0f; // velocidade do movimento do barril
    public float ladderChance = 1f; // chance de descer a escada
    private Rigidbody2D rb;
    private BoxCollider2D bcPlataform;
    private bool descendingLadder = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // obtém o componente Rigidbody2D
    }

    // Update is called once per frame
    void Update()
    {
        if (descendingLadder)
        {
            // move o barril verticalmente para baixo
            
            rb.velocity = new Vector2(0, -speed);
        }
        else
        {
            // move o barril horizontalmente
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

    // Detecta a colisão com a plataforma ou escada
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground");
            // inverte a direção do movimento do barril
            //bcPlataform = collision.gameObject.GetComponent<BoxCollider2D>(); // obtém o componente Rigidbody2D da plataforma
            speed = -speed;
            descendingLadder = false;
        }
        else if (collision.gameObject.CompareTag("Ladder"))
        {
            Debug.Log("Ladder");
            // decide se o barril deve descer a escada
            if (Random.Range(0f, 1f) < ladderChance)
            {
                descendingLadder = true;
                //desativando o collider da plataforma para o barril descer a escada
                //bcPlataform.enabled = false;
            }else{
                //bcPlataform.enabled = true;
            }
        }
    }

    // Detecta quando o barril deixa de colidir com a escada
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            descendingLadder = false;
        }
    }
}