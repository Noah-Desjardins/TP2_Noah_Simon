using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupEnnemi1 : MonoBehaviour
{
    float direction = 0;
    [SerializeField]float vitesseDeplacementMin = 1;
    [SerializeField] float vitesseDeplacementMax = 5;
    float vitesse = 0;
    // Start is called before the first frame update
    void Start()
    {
        int nb = Random.Range(0,2);
        if (nb == 0)
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
        transform.Translate(new Vector2(direction, -1) * vitesse * Time.deltaTime, Space.Self);
        if (transform.position.y <= -12)
        {
            Destroy(gameObject);
        }
    }
}
