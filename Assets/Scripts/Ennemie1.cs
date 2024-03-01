using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemie1 : MonoBehaviour
{
    [SerializeField] GameObject DyingAnimation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //permet la destruction de l'autobus et de la balle
        if (collision.tag == "Balle")
        {
            GameObject.Instantiate(DyingAnimation, transform.position, Quaternion.identity);
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
