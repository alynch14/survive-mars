using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private int hp;
    private const int MAX_HP = 1000;
    

    // Start is called before the first frame update
    void Start()
    {
        hp = MAX_HP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Landing Pad"))
        {
            
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hp -= 100;
        }
    }
}
