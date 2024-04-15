using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisons : MonoBehaviour
{
    public GameObject gm;
    

    
    private void OnCollisionEnter2D(Collision2D other) {
        //Debug.Log("Colidiu");
        int roupaCorreta = gm.GetComponent<GameManager>().roupaCorreta;


        if(other.gameObject.tag == "Red"){
            if(roupaCorreta == 2 && gm.GetComponent<GameManager>().roupaAtual == 2){
                gm.GetComponent<GameManager>().buff();
                other.gameObject.SetActive(false);
            }else{
                gm.GetComponent<GameManager>().RoupaFalha();
                gm.GetComponent<GameManager>().roupaAtual = 2;
                other.gameObject.SetActive(false);
            }
        }
        if(other.gameObject.tag == "Green"){
            if(roupaCorreta == 1 && gm.GetComponent<GameManager>().roupaAtual == 1){
                gm.GetComponent<GameManager>().buff();
                other.gameObject.SetActive(false);
            }else{
                gm.GetComponent<GameManager>().RoupaFalha();
                gm.GetComponent<GameManager>().roupaAtual = 1;
                other.gameObject.SetActive(false);
            }
        }
        if(other.gameObject.tag == "Blue"){
            if(roupaCorreta == 0 && gm.GetComponent<GameManager>().roupaAtual == 0){
                gm.GetComponent<GameManager>().buff();
                other.gameObject.SetActive(false);
            }else{
                gm.GetComponent<GameManager>().RoupaFalha();
                gm.GetComponent<GameManager>().roupaAtual = 0;
                other.gameObject.SetActive(false);
            }
        }

        if(other.gameObject.tag == "Anel"){
            if(roupaCorreta == gm.GetComponent<GameManager>().roupaAtual){
                gm.GetComponent<GameManager>().AneisPassados();
                other.gameObject.SetActive(false);
            }
        }
    }
}
