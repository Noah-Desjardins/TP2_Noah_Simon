using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemie2 : MonoBehaviour
{

    [SerializeField] GameObject DyingAnimation;
    [SerializeField] GameObject projectile;

    [SerializeField] float TempsDepartTirer = 3;
    float TempsTirer;

    Joueur joueur;
    Score score;

    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindObjectOfType<Joueur>();
        score = GameObject.FindObjectOfType<Score>();
        TempsTirer = TempsDepartTirer;
    }

    void OnEnable()
    {
        TempsTirer = TempsDepartTirer;
    }


    // Update is called once per frame
    void Update()
    {
        //tirer
        TempsTirer -= Time.deltaTime;
        if (TempsTirer <= 0)
        {
            Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
            TempsTirer = TempsDepartTirer;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //permet la destruction de l'ennemie et de la balle
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
