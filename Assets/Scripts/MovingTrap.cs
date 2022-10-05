using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrap : Trap
{
    public Vector2 max;
    public Vector2 min;
    public int speed;
    bool moveR = true;

    private void Start()
    {
        max = transform.position + (Vector3)max;
        min = transform.position + (Vector3)min;
    }
    void Update()
    {
        if (moveR)
        {
            transform.position = Vector3.MoveTowards(transform.position, max, speed * Time.deltaTime);
            if(transform.position == (Vector3)max)
            {
                moveR = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, min, speed * Time.deltaTime);
            if (transform.position == (Vector3)min)
            {
                moveR = true;
            }
        }
    }
}
