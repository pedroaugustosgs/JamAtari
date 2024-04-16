using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using TMPText = TMPro.TextMeshProUGUI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int vidas = 3;
    private int cont = 0;
    private int score = 0;
    private float timer = 60.0f; // Timer de 1 minuto
    public int roupaAtual = 0;
    public int roupaCorreta = 0; // 0 = Azul, 1 = Verde, 2 = Vermelho
    public GameObject Player;
    private float originalSpeed;
    private float buffDuration = 5.0f; // Duração do buff em segundos
    public Sprite roupaAzul;
    public Sprite roupaVerde;
    public Sprite roupaVermelha;

    public GameObject linha;
    public GameObject Roupa;
    public GameObject scoreCanvas;
    public GameObject timerCanvas;
    public GameObject vida1;
    public GameObject vida2;
    public GameObject vida3;

    public GameObject anel;
    public GameObject anel2;
    public GameObject anel3;
    public GameObject anel4;

    private Image linhaUI = null;
    private Image RoupaUI = null;
    private TMPText scoreUI = null;
    private TMPText timerUI = null;

    public Sprite linhaAzul;
    public Sprite linhaVerde;
    public Sprite linhaVermelha;

    public int aneisTotal = 4;
    public int aneisPassados = 0;



    void Start()
    {
        linhaUI = linha.GetComponent<Image>();
        RoupaUI = Roupa.GetComponent<Image>();
        scoreUI = scoreCanvas.GetComponent<TMPText>();
        timerUI = timerCanvas.GetComponent<TMPText>();  

        originalSpeed = Player.GetComponent<PlayerMovement>().speed;
        NewRoupa();
        UpdateUI();
    }

    public void NewRoupa()
    {
        roupaCorreta = Random.Range(0, 3);  // 0, 1, 2
        roupaAtual = Random.Range(0, 3);  // 0, 1, 2
        Debug.Log(roupaCorreta);
        //  
        UpdateUI();
    }

    public void RoupaCompleta()
    {
        //
        anel.SetActive(true);
        anel2.SetActive(true);
        anel3.SetActive(true);
        anel4.SetActive(true);
        aneisPassados = 0;
        timer = 60.0f;
        score++;
        roupaCorreta = Random.Range(0, 3);  // 0, 1, 2
        UpdateUI();
    }

    public void RoupaFalha()
    {
        // 
        anel.SetActive(true);
        anel2.SetActive(true);
        anel3.SetActive(true);
        anel4.SetActive(true);
        aneisPassados = 0;
        timer = 60.0f;
        roupaCorreta = Random.Range(0, 3);  // 0, 1, 2
        //restartar o timer
        UpdateUI();
        

    }
    
    public bool AneisPassados()
    {
        aneisPassados++;
        if (aneisPassados == aneisTotal)
        {
            // Ganhou
            Debug.Log("Ganhou");
            RoupaCompleta();
        }
        UpdateUI();
    }

    public void buff(){
        Player.GetComponent<PlayerMovement>().speed *= 1.2f; // Aumenta a velocidade em 20%
        Invoke("removeBuff", buffDuration); // Remove o buff após buffDuration segundos
        UpdateUI();
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
            vidas--; // Decrementa as vidas
            if (vidas == 0) // Se as vidas acabaram
            {
                // Game Over
                Debug.Log("Game Over");
            }
        
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        if (roupaAtual == 0)
        {
            linhaUI.GetComponent<Image>().sprite = linhaAzul;
        }
        else if (roupaAtual == 1)
        {
            linhaUI.GetComponent<Image>().sprite = linhaVerde;
        }
        else if (roupaAtual == 2)
        {
            linhaUI.GetComponent<Image>().sprite = linhaVermelha;
        }
        // Atualiza a UI
        if (roupaCorreta == 0)
        {
            RoupaUI.GetComponent<Image>().sprite = roupaAzul;
        }
        else if (roupaCorreta == 1)
        {
            RoupaUI.GetComponent<Image>().sprite = roupaVerde;
        }
        else if (roupaCorreta == 2)
        {
            RoupaUI.GetComponent<Image>().sprite = roupaVermelha;
        }

        scoreUI.text = "Score: " + score;
        timerUI.text = "Timer: " + timer.ToString("F0");

        if (vidas == 3)
        {
            vida1.SetActive(true);
            vida2.SetActive(true);
            vida3.SetActive(true);
        }
        else if (vidas == 2)
        {
            vida1.SetActive(true);
            vida2.SetActive(true);
            vida3.SetActive(false);
        }
        else if (vidas == 1)
        {
            vida1.SetActive(true);
            vida2.SetActive(false);
            vida3.SetActive(false);
        }
        else if (vidas == 0)
        {
            vida1.SetActive(false);
            vida2.SetActive(false);
            vida3.SetActive(false);
        }
    }
}
