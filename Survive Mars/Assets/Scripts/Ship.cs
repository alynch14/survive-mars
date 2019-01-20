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
    public GameObject missile;

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

        if (Input.GetMouseButton(0))
        {
            Instantiate(missile, new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, gameObject.transform.position.z), new Quaternion());
        }
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
            gameObject.GetComponentInParent<Transform>().RotateAround(collision.gameObject.GetComponentInParent<Transform>().GetComponentInParent<Transform>().position, new Vector3(0, 0, 1), 0.1f);
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

    public string getOxygenLevel()
    {
        return oxygenLevel.ToString();
    }

    public string getHP()
    {
        return hp.ToString();
    }
}
