using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float dir;
    [SerializeField] private float jumpHeight = 1;
    [SerializeField] private float fallSpeed = 0.1f;
    private float Yvelocity = 0;
    private float Xvelocity = 0;
    [SerializeField] private float speed = 10f;

    private float floorHeight = 0.5f;
    [SerializeField] private Transform feet;
    private ContactFilter2D filter;
    private bool isGrounded = false;
    Collider2D[] results = new Collider2D[1];

    float altura = 0f;
    float alturamax = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Time.maximumDeltaTime = 0.002f;
    }

    // Update is called once per frame
    void Update()
    {
        //gravidade
        Yvelocity += -fallSpeed;
        //Debug.Log(Yvelocity);

        if (Physics2D.OverlapBox(feet.position, feet.localScale, 0, filter, results) > 0 && Yvelocity < 0)
        {
            //Debug.Log("tocou  no chão");
            Yvelocity = 0;
            Vector2 surface = Physics2D.ClosestPoint(transform.position, results[0]) + Vector2.up * floorHeight;
            transform.position = new Vector3(transform.position.x, surface.y, 0);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
             Yvelocity = jumpHeight;
            isGrounded = false;
        }

        altura = transform.position.y;
        if (altura > alturamax)
        {
            alturamax = altura;
            Debug.Log(alturamax);
        }


        
        dir =  Input.GetAxis("Horizontal");

        Xvelocity = dir * speed;
        //Debug.Log(Yvelocity);
        //Debug.Log(jumpHeight);
        transform.Translate(new Vector3(Xvelocity, Yvelocity, 0) * Mathf.Clamp( Time.deltaTime, 0 , 0.002f));
    }


}
