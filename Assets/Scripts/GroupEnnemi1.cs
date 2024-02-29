using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupEnnemi1 : MonoBehaviour
{
    // la direction que l'ennemi bouge
    float direction = 0;

    //la vitesse que l'ennemie bouge
    [SerializeField]float vitesseDeplacementMin = 1;
    [SerializeField] float vitesseDeplacementMax = 5;
    float vitesse = 0;
    Vector2 positionActuelle = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        positionActuelle = transform.position;  
        if (positionActuelle.x < 0)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
        vitesse = Random.Range(vitesseDeplacementMin, vitesseDeplacementMax);
    }

    // Update is called once per frame
    void Update()
    {
        //bouge l'ennemie
        transform.Translate(new Vector2(direction, -1) * vitesse * Time.deltaTime, Space.Self);
        
        //detruit les enemie s'ils son plus bas que 12 dans les y
        if (transform.position.y <= -12)
        {
            Destroy(gameObject);
        }
    }
}
