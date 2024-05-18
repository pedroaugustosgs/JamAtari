using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallVoid : MonoBehaviour
{
    [SerializeField] private GameObject GameManager;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject);
       other.gameObject.transform.position = new Vector2(-4.52f, -3.64f);
        GameManager.GetComponent<GameManager>().RoupaFalha();
    }
}
