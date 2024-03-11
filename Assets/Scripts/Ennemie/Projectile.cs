using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    GameObject joueur;
    [SerializeField] float vitesse = 3;

    Vector3 distance = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindGameObjectWithTag("Player");

        if ( joueur != null )
            distance = joueur.transform.position - gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(distance * vitesse * Time.deltaTime, Space.World);
    }
}
