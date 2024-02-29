using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    float tempsExplode = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempsExplode += Time.deltaTime * 3;
        transform.localScale = (new Vector3(Mathf.Sin(tempsExplode) * 0.5f, Mathf.Sin(tempsExplode) * 0.5f, Mathf.Sin(tempsExplode)* 0.5f));
        if (Mathf.Sin(tempsExplode) <= 0)
            Destroy(gameObject);
    }
}
