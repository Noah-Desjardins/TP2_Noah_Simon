using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    //limit d'apparition des ennemies
    [SerializeField] int limitX = 7;
    [SerializeField] float hauteurDepartennemie1 = 11f;

    //temps avant prochain group d'ennemie 1 apparait
    [SerializeField] float timeDepartennemie1 = 5f;
    float timeEnnemie1;

    //temps avant prochain group d'ennemie 2 apparait
    [SerializeField] float timeDepartennemie2 = 5f;
    float timeEnnemie2;

    [SerializeField] GameObject groupEnnemie1;
    [SerializeField] GameObject groupEnnemie2;
    [SerializeField] GameObject powerUp;

    [SerializeField] float frequencePowerUps = 15;
    float actualScorePowerUps;
    Score score;

    private void Start()
    {
        timeEnnemie1 = timeDepartennemie1;
        timeEnnemie2 = timeDepartennemie2;
        score = GameObject.FindObjectOfType<Score>();
        actualScorePowerUps = frequencePowerUps;

    }
    // Update is called once per frame
    void Update()
    {
        //spawn les group d'ennemies 1
        timeDepartennemie1 -= Time.deltaTime;
        if (timeDepartennemie1 <= 0)
        {
            float x = Random.Range(-limitX, limitX);
            Vector2 position = new(x, hauteurDepartennemie1);
            GameObject busTemp =  ObjectPool.instance.GetPooledObject(groupEnnemie1);
            busTemp.transform.position = position;
            busTemp.transform.rotation = Quaternion.identity;
            busTemp.SetActive(true);
            if (timeEnnemie1 > 3)
                timeEnnemie1 -= 0.2f;
            timeDepartennemie1 = timeEnnemie1;
        }

        //Spawn les group ennemies 2
        timeDepartennemie2 -= Time.deltaTime;
        if (timeDepartennemie2 <= 0)
        {
            float x = Random.Range(-limitX, limitX);
            Vector2 position = new(x, hauteurDepartennemie1);
            GameObject metroidTemp = ObjectPool.instance.GetPooledObject(groupEnnemie2);
            metroidTemp.transform.position = position;
            metroidTemp.transform.rotation = Quaternion.identity;
            metroidTemp.SetActive(true);
            if (timeEnnemie2 > 2)
                timeEnnemie2 -= 0.1f;
            timeDepartennemie2 = timeEnnemie2;
        }

        //Spawn les power ups à tout les x (frequencePowerUps) ennemis
        if (score.score % actualScorePowerUps == 0 && score.score != 0)
        {
            actualScorePowerUps += frequencePowerUps;
            float x = Random.Range(-limitX, limitX);
            Vector2 position = new(x, hauteurDepartennemie1);
            GameObject powerUpTemp = ObjectPool.instance.GetPooledObject(powerUp);
            powerUpTemp.transform.position = position;
            powerUpTemp.transform.rotation = Quaternion.identity;
            powerUpTemp.SetActive(true);
        }

    }
}
