using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Joueur : MonoBehaviour
    
{
    [SerializeField] float vitessePersonnage = 5;
    Vector2 direction = Vector2.zero;

    //Permet de simuler une course
    bool running = false;
    float tempsEntreChaqueBons = 0.5f;
    Vector2 tailleSol;
    Vector2 tailleCourse = new Vector2(1.3f,1.3f);

    //Permet tirer
    float fire = 0;
    float fireDelay = 0;
    [SerializeField] float vitesseTir = 5;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bullet2;
    [SerializeField] GameObject bullet3;
    GameObject tireur;

    //Vie Character
    int vie = 1;

    //Mort
    [SerializeField] GameObject joueurMort;

    // Start is called before the first frame update
    void Start()
    {
        tailleSol = transform.localScale;
        tireur = GameObject.FindGameObjectWithTag("Tireur");
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(direction * Time.deltaTime * vitessePersonnage,Space.Self);

        
        GererSaut();
        if (bullet != null)
            GererArme();
        if (vie <= 0)
            Destroy(gameObject);

        
    }
    //"Animation" de petit saut à chaque (demi seconde) => (hard codé)
    public void GererSaut()
    {
        if (running)
        {
            tempsEntreChaqueBons -= Time.deltaTime;
            if (tempsEntreChaqueBons <= 0)
            {
                if (transform.localScale.magnitude > tailleSol.magnitude)
                    transform.localScale = tailleSol;
                else
                    transform.localScale = tailleCourse;
                tempsEntreChaqueBons = 0.5f;
            }
        }
        else
            transform.localScale = tailleSol;
    }

    public void Toucher()
    {
        vie--;
        if (vie == 0)
        {
            Destroy(gameObject);
            GameObject.Instantiate(joueurMort, transform.position, Quaternion.Euler(new Vector3(0, -90, 0)));
        }
    }

    public void GererArme()
    {
        if (fire > 0 && fireDelay <= 0)
        {
            if (vie == 1)
            {
                GameObject bulletTemp1 = ObjectPool.instance.GetPooledObject(bullet);
                bulletTemp1.transform.position = tireur.transform.position;
                bulletTemp1.transform.rotation = tireur.transform.rotation;
                bulletTemp1.SetActive(true);
            }
            if (vie == 2)
            {
                GameObject bulletTemp2 = ObjectPool.instance.GetPooledObject(bullet2);
                bulletTemp2.transform.position = tireur.transform.position;
                bulletTemp2.transform.rotation = tireur.transform.rotation;
                bulletTemp2.SetActive(true);
            }
            if (vie == 3)
            {
                GameObject bulletTemp3 = ObjectPool.instance.GetPooledObject(bullet3);
                bulletTemp3.transform.position = tireur.transform.position;
                bulletTemp3.transform.rotation = tireur.transform.rotation;
                bulletTemp3.SetActive(true);
            }
                
            fireDelay = 1 / vitesseTir;
        }
        fireDelay -= Time.deltaTime;
    }
    public void Move(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
        running = context.ReadValue<Vector2>().magnitude > 0;
    }
    public void Fire(InputAction.CallbackContext context)
    {
        fire = context.ReadValue<float>();  
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PowerUp" && vie < 3)
            vie++;
        if (collision.tag == "Projectile")
        {
            Toucher();
            Destroy(collision.gameObject);
        }

    }

}
