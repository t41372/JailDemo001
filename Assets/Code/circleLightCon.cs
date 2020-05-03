using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class circleLightCon : MonoBehaviour
{
    private double x = 0;
    private double y = 0;
    private float radius = 5;
    private bool reverse = false;
    private float timePast = 0;
    private float timeSpan = 0.025f;
    private float walkSpeed = 0.25f;
    Vector2 center = new Vector2(0,16);
    Vector2 nowCor;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePast += Time.deltaTime;
        if(timePast >= timeSpan)
        {
            
            if(x >= radius)
                reverse = true;
            else if(x <= -radius)
                reverse = false;

            if(reverse)
            {
                x -= walkSpeed;
                y = -Math.Sqrt((radius*radius)-(x*x));
            }
            else
            {
                x += walkSpeed;
                y = Math.Sqrt((radius*radius)-(x*x));
            }
            
            
            //Debug.Log(transform.position + "x = " + x + "y = " + y);
            nowCor = new Vector2(center.x + (float)x, center.y + (float)y);
            transform.position = nowCor;
        }


    }
}
