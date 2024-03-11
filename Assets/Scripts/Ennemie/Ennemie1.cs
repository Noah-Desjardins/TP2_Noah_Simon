using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ennemie1 : MonoBehaviour
{
    [SerializeField] GameObject DyingAnimation;
    Joueur joueur;
    Score score;

    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindObjectOfType<Joueur>();
        score = GameObject.FindObjectOfType<Score>();
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
            score.Agmenter();
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        if (collision.tag == "Player")
        {
            GameObject.Instantiate(DyingAnimation, transform.position, Quaternion.identity);
            joueur.Toucher();
            gameObject.SetActive(false);
        }
    }
}
