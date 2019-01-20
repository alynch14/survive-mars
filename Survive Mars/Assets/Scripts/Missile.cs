using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    bool isPlayer;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy") && gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    public void setIsPlayer(bool flag)
    {
        isPlayer = flag;
    }
}
