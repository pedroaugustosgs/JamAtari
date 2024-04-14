using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisons : MonoBehaviour
{
    public GameObject gm;
    

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other) {
        int roupaCorreta = gm.GetComponent<GameManager>().roupaCorreta;


        if(other.gameObject.tag == "Red"){
            if(roupaCorreta == 2 && gm.GetComponent<GameManager>().roupaAtual == 2){
                gm.GetComponent<GameManager>().buff();
            }else{
                gm.GetComponent<GameManager>().RoupaFalha();
            }
        }
        if(other.gameObject.tag == "Green"){
            if(roupaCorreta == 1 && gm.GetComponent<GameManager>().roupaAtual == 1){
                gm.GetComponent<GameManager>().buff();
            }else{
                gm.GetComponent<GameManager>().RoupaFalha();
            }
        }
        if(other.gameObject.tag == "Blue"){
            if(roupaCorreta == 0 && gm.GetComponent<GameManager>().roupaAtual == 0){
                gm.GetComponent<GameManager>().buff();
            }else{
                gm.GetComponent<GameManager>().RoupaFalha();
            }
        }

        

    }
}
