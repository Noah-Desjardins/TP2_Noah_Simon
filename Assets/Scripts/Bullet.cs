using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float vitesseBalle = 5;
    float limitY = 12;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * Time.deltaTime * vitesseBalle, Space.World);
        if(transform.position.y > limitY)
        {
            Destroy(gameObject);
        }
    }
}
