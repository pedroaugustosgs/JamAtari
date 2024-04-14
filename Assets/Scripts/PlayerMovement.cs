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

    Collider2D playerCollider;

    private float floorHeight = 0.5f;
    [SerializeField] private Transform feet;
    [SerializeField] private ContactFilter2D filter;
    private bool isGrounded = false;
    Collider2D[] results = new Collider2D[1];

    

    float altura = 0f;
    float alturamax = 0f;

    float bufferJump;
    [SerializeField] float bufferTime = 1;

    bool InputW;
    bool InputE;
    [SerializeField]  bool isClimbing = false;
    float dirVertical;

    bool isLadder;
    bool isLadderExit;
    Collider2D colLadder;

    // Start is called before the first frame update
    void Start()
    {
       playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Inputs
        InputW = Input.GetKeyDown(KeyCode.W);
        InputE = Input.GetKeyDown(KeyCode.E);

        dir = Input.GetAxis("Horizontal");

        dirVertical = Input.GetAxis("Vertical");
        //Debug.Log(isClimbing);

        
        if (isLadder  & InputE)
        {
            
            if(isClimbing == false)
            {
                isClimbing = true;
            }
            else
            {
                isClimbing = false;
            }
               
        }else if (!isLadder)
        {
            isClimbing= false;
        }

        if (isClimbing)
        {
            Climbing(colLadder);
        }
        else
        {
            Moviment();
        }

        
    }


    void Moviment()
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


        if (InputW)
        {
            bufferJump = bufferTime;
        }
        else
        {
            bufferJump -= Time.deltaTime;
        }



        if (bufferJump > 0f && isGrounded)
        {

            Yvelocity = jumpHeight;
            isGrounded = false;
            bufferJump = 0f;
        }

        altura = transform.position.y;
        if (altura > alturamax)
        {
            alturamax = altura;
            Debug.Log(alturamax);
        }


        Xvelocity = dir * speed;
        //Debug.Log(Yvelocity);
        //Debug.Log(jumpHeight);
        transform.Translate(new Vector3(Xvelocity, Yvelocity, 0) * Mathf.Clamp(Time.deltaTime, 0, 0.002f));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Collider2D col = collision;
        
        if  (col.gameObject.CompareTag("Ladder"))
        {
            isLadder = true;
            colLadder = collision;
        };
        
        
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        
         Collider2D col1 = collision;
        if (col1.gameObject.CompareTag("Ladder"))
        {
            isLadder = false;
        }
        
        
    }
    
    void Climbing(Collider2D colLadder)
    {

        transform.Translate(new Vector3(colLadder.transform.position.x - transform.position.x, jumpHeight * dirVertical * 0.001f, 0));

    }
}
