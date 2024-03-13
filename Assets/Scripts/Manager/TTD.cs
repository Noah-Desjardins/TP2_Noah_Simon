using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTD : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float tempsVie = 3;
    [SerializeField] float limiteY = -12;
    float tempsInit;
    void OnEnable()
    {
        tempsInit = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > tempsInit + tempsVie)
            gameObject.SetActive(false);
        //il n'y a pas juste du temps qui désactive l'objet il y a aussi sa position
        if (gameObject.transform.position.y < limiteY)
            gameObject.SetActive(false);
    }
}
