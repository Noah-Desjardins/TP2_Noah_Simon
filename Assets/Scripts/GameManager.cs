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

    [SerializeField] GameObject groupEnnemie1;

    private void Start()
    {
        timeEnnemie1 = timeDepartennemie1;
    }
    // Update is called once per frame
    void Update()
    {
        timeDepartennemie1 -= Time.deltaTime;
        if (timeDepartennemie1 <= 0)
        {
            float x = Random.Range(-limitX, limitX);
            Vector2 position = new(x, hauteurDepartennemie1);
            Instantiate(groupEnnemie1, position, Quaternion.identity);
            if(timeEnnemie1 > 3)
                timeEnnemie1 -= 0.1f;
            timeDepartennemie1 = timeEnnemie1;

        }
    }
}
