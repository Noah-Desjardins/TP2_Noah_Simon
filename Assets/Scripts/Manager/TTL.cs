using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTL : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float tempsVie = 3;
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
        if (gameObject.transform.position.y < -12)
            Destroy(gameObject);
    }
}
