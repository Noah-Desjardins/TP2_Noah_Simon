using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Background avec repetition
    [SerializeField] GameObject background;

    //Camera
    [SerializeField] GameObject Camera;

    //limit d'apparition des ennemies
    [SerializeField] int limitX = 7;
    [SerializeField] float hauteurDepartennemie1 = 11f;

    //temps avant prochain group d'ennemie 1 apparait
    [SerializeField] float timeDepartennemie1 = 5f;
    float timeEnnemie1;

    [SerializeField] GameObject groupEnnemie1;

    private void Start()
    {
        timeEnnemie1 = timeDepartennemie1;
        GameObject.Instantiate(background,new Vector3(Camera.transform.position.x, Camera.transform.position.y, Camera.transform.position.z + 30) , Camera.transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        timeDepartennemie1 -= Time.deltaTime;
        if (timeDepartennemie1 <= 0)
        {
            float x = Random.Range(-limitX, limitX);
            Vector2 position = new(x, hauteurDepartennemie1);
            GameObject busTemp = ObjectPool.instance.GetPooledObject(groupEnnemie1);
            busTemp.transform.position = position;
            busTemp.transform.rotation = Quaternion.identity;
            busTemp.SetActive(true);
               



            if (timeEnnemie1 > 3)
                timeEnnemie1 -= 0.1f;
            timeDepartennemie1 = timeEnnemie1;

        }

    }
}
