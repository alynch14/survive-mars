using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject laser;
    private Vector3 currentDirection;
    public float acceleration;
    public float currentVelocityX;
    public float currentVelocityY;
    public const float MAX_VELOCITY = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xVel = 0.0f;
        float yVel = 0.0f;

        if (Input.GetKey(KeyCode.A))
        {
            xVel -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            xVel += 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            yVel += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            yVel -= 1;
        }

        xVel *= Time.deltaTime * acceleration;
        yVel *= Time.deltaTime * acceleration;

        currentVelocityX = (Mathf.Abs(currentVelocityX) > MAX_VELOCITY) ? MAX_VELOCITY * Mathf.Sign(xVel) : (xVel == 0)?  0 : currentVelocityX + xVel;
        currentVelocityY = (Mathf.Abs(currentVelocityY) > MAX_VELOCITY) ? MAX_VELOCITY * Mathf.Sign(yVel) : (yVel ==0)? 0 : currentVelocityY + yVel;

        currentDirection = new Vector3(currentVelocityX, currentVelocityY);
        gameObject.transform.Translate(currentDirection);

    }
}
