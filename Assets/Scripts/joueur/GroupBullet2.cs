using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroupBullet2 : MonoBehaviour
{
    // Start is called before the first frame update
    List<Bullet> bullets = new List<Bullet>();
    void Start()
    {
        bullets = GetComponentsInChildren<Bullet>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        foreach (Bullet bullet in bullets)
        {
            print(bullets.Count);
             if (!bullet.gameObject.activeInHierarchy)
                 bullet.gameObject.SetActive(true);
        }
           
    }
}
