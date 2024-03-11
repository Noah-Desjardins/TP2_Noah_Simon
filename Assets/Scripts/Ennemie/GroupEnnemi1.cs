using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    List<Ennemie1> ennemis = new List<Ennemie1>();
    // Start is called before the first frame update
    void Start()
    {
        ennemis = GetComponentsInChildren<Ennemie1>().ToList();
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
    }
    void OnEnable()
    {
        vitesse = Random.Range(vitesseDeplacementMin, vitesseDeplacementMax);
        for (int i = 0; i < ennemis.Count; i++)
            if (!ennemis[i].gameObject.activeInHierarchy)
                ennemis[i].gameObject.SetActive(true);
    }
}
