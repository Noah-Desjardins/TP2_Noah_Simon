using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTL : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float tempsVie = 3;
    [SerializeField] float limiteY = -12;

    float tempsInit;
    void Start()
    {
        tempsInit = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > tempsInit + tempsVie)
            Destroy(gameObject);        
        //il n'y a pas juste du temps qui désactive l'objet il y a aussi sa position
        if (gameObject.transform.position.y < limiteY)
            Destroy(gameObject);
    }
}
