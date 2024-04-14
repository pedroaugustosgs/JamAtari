using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int vidas = 3;
    private int score = 0;
    private float timer = 60.0f; // Timer de 1 minuto
    public int roupaAtual = 0;
    public int roupaCorreta = 0; // 0 = Azul, 1 = Verde, 2 = Vermelho
    public GameObject Player;
    private float originalSpeed;
    private float buffDuration = 5.0f; // Duração do buff em segundos

    void Start()
    {
        originalSpeed = Player.GetComponent<PlayerMovement>().speed;
        NewGame();
    }

    public void NewGame()
    {
        vidas = 3;
        score = 0;
        roupaCorreta = Random.Range(0, 3);  // 0, 1, 2
        Debug.Log(roupaCorreta);
        //  
    }

    public void RoupaCompleta()
    {
        //
        score++;
        roupaCorreta = Random.Range(0, 3);  // 0, 1, 2
    }

    public void RoupaFalha()
    {
        //
        vidas--; 
        if (vidas <= 0)
        {
            // Game Over
        }
        roupaCorreta = Random.Range(0, 3);  // 0, 1, 2
    }
    
    public void buff(){
        Player.GetComponent<PlayerMovement>().speed *= 1.2f; // Aumenta a velocidade em 20%
        Invoke("removeBuff", buffDuration); // Remove o buff após buffDuration segundos
    }

    void removeBuff()
    {
        Player.GetComponent<PlayerMovement>().speed = originalSpeed; // Restaura a velocidade original
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; // Decrementa o timer

        if (timer <= 0) // Se o timer acabou
        {
            RoupaFalha(); // Chama a função RoupaFalha
            timer = 60.0f; // Reinicia o timer
        }
    }


}
