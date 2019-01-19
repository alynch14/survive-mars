using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private int hp;
    private const int MAX_HP = 1000;
    private int oxygenLevel;
    private const int MAX_OXYGEN = 10000;
    private Vector3 prevPosition;
    bool refueling;

    // Start is called before the first frame update
    void Start()
    {
        hp = MAX_HP;
        prevPosition = gameObject.transform.position;
        refueling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (refueling)
        {
            gameObject.transform.Rotate(0f, 0.1f, 0f);
            oxygenLevel++;
            if(oxygenLevel >= MAX_OXYGEN)
            {
                refueling = false;
                oxygenLevel = MAX_OXYGEN;
            }
            if (Input.GetKey(KeyCode.E))
            {
                refueling = false;
            }
        }
        else
        {
            if (!prevPosition.Equals(gameObject.transform.position))
            {
                oxygenLevel--;
            }
        }
        prevPosition = gameObject.transform.position;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Landing Pad"))
        {
            refueling = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hp -= 100;
        }
    }

    public void RestoreHP()
    {
        int difference = MAX_HP - hp;
        hp = MAX_HP;
        oxygenLevel -= difference;
    }
}
