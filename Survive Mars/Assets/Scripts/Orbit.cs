using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public float orbitSpeed;
    public GameObject planetOrbit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.RotateAround(planetOrbit.transform.position, new Vector3(0, 0, 1), orbitSpeed);
    }
}
