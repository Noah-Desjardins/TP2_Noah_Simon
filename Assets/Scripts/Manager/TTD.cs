using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTD : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float tempsVie = 3;
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
        if (gameObject.transform.position.y < -12)
            gameObject.SetActive(false);
    }
}
