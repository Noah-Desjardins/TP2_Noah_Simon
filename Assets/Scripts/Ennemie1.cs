using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemie1 : MonoBehaviour
{
    [SerializeField] float vitesseMouvement = 1;
    Vector2 direction = new Vector2(0, -1);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * vitesseMouvement * Time.deltaTime, Space.Self);
        if (transform.position.y <= -9)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Balle")
        {
            Destroy(gameObject);
        }

    }
}
