using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BarrelController : MonoBehaviour
{
    public float speed = 3f; // Velocidade de movimento dos barris
    public Transform[] ladderWaypoints; // Pontos de referência da escada
    public float ladderChance = 0.5f; // Chance de descer a escada

    private int currentWaypointIndex = 0;
    private Rigidbody2D rb;
    private bool isDescendingLadder = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (ladderWaypoints.Length == 0)
        {
            Debug.LogError("É necessário definir os pontos de referência da escada.");
        }
    }

    void Update()
    {
        if (!isDescendingLadder)
        {
            Move();
            CheckForLadder();
        }
    }

    void Move()
    {
        Vector2 movement = new Vector2(speed, rb.velocity.y);
        rb.velocity = movement;
    }

    void CheckForLadder()
    {
        if (currentWaypointIndex < ladderWaypoints.Length &&
            transform.position.x >= ladderWaypoints[currentWaypointIndex].position.x)
        {
            if (Random.value <= ladderChance)
            {
                GetComponent<Collider2D>().enabled = false;

                isDescendingLadder = true;
                Invoke(nameof(DescendLadder), 0f); // Tempo de espera para começar a descer a escada

                GetComponent<Collider2D>().enabled = true;
            }
            else
            {
                currentWaypointIndex++;
            }
        }
    }

    void DescendLadder()
{
    if (currentWaypointIndex < ladderWaypoints.Length)
    {
         
        Vector2 targetPosition = new Vector2(ladderWaypoints[currentWaypointIndex].position.x, transform.position.y);
        StartCoroutine(MoveToPosition(targetPosition, 1f)); // Movimento suave para a posição de destino
        currentWaypointIndex++;
        isDescendingLadder = false;

        
    }
}

IEnumerator MoveToPosition(Vector2 targetPosition, float duration)
{
    float time = 0;
    Vector2 startPosition = transform.position;
    while (time < duration)
    {
        transform.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
        time += Time.deltaTime;
        yield return null;
    }
    transform.position = targetPosition;
}

}
