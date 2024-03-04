using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float vitesseDefilement = 2;
    [SerializeField] new Renderer renderer;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        renderer.material.mainTextureOffset = new Vector2(Time.time * vitesseDefilement,0);
    }
}
