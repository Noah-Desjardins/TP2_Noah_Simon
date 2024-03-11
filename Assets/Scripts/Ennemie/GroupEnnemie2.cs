using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GroupEnnemie2 : MonoBehaviour
{
    //la vitesse que l'ennemie bouge
    [SerializeField] float vitesseDeplacementMin = 1;
    [SerializeField] float vitesseDeplacementMax = 5;
    float vitesse = 0;
    List<Ennemie2> ennemis = new List<Ennemie2>();

    [SerializeField] float distanceMax = 1.5f;
    Vector3 pos = Vector3.zero;
    float posY;
    // Start is called before the first frame update
    void Start()
    {
        ennemis = GetComponentsInChildren<Ennemie2>().ToList();
        vitesse = Random.Range(vitesseDeplacementMin, vitesseDeplacementMax);
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //bouge l'ennemie vers le bas
        transform.Translate(new Vector2(0, -1) * vitesse * Time.deltaTime, Space.Self);

        //bouge l'ennemie vers la droite et la gauche
        posY = transform.position.y;
        float newX = pos.x + distanceMax * Mathf.Sin(Time.time * vitesse);
        transform.position = new Vector3(newX, posY, 0);
    }
    void OnEnable()
    {
        pos = transform.position;
        vitesse = Random.Range(vitesseDeplacementMin, vitesseDeplacementMax);
        for (int i = 0; i < ennemis.Count; i++)
            if (!ennemis[i].gameObject.activeInHierarchy)
                ennemis[i].gameObject.SetActive(true);
    }
}
