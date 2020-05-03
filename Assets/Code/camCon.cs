using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camCon : MonoBehaviour
{
    //attribute of the camera---
    private float timeSlice = 0.025f;//means every timeSlice second, we travel, kind of like we fresh the camera per timeSlice second
    //attribute finished===

    public bool followSomeone = false;
    
    private bool isMove = false;
    private bool changeX = false;
    private bool changeY = false;

    public float moveSpeed = 0;// 1m/s  d=v/t, given v=1, v/d = t, d = target
    private float timePast = 0;
    private float time_need_y = 0;
    private float time_need_x = 0;
    private Vector2 change;//change px per timeSlice second
    
    GameObject leader;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //!Follow Me Function---------------
        if(followSomeone)
        {
            transform.position = new Vector3(leader.transform.position.x, leader.transform.position.y, transform.position.z);
        }

        //!Follow Me Function Ended============
        
        //* Move Cam Functioning Area --------------------------------------
        if(isMove)//if we need to move
        {
            timePast += Time.deltaTime;

            //! Stopping checking procedure Start----------------

            if(time_need_y >= 0)//if y travel time has not end
            {
                time_need_y -= Time.deltaTime;//minus the time waste now
            }else{//if travel y time ended
                time_need_y = 0;//make sure time is not negative, we initialize it for next time we use it
                change.y = 0;//stop travelling on y
                changeY = false;
            }

            if(time_need_x >= 0)//if x travel time has not end
            {
                time_need_x -= Time.deltaTime;//minus the time waste now
            }else{//if travel x time ended
                time_need_x = 0;//make sure time is not negative, we initialize it for next time we use it
                change.x = 0;//stop travelling on y
                changeX = false;
            }

            if(changeX == false && changeY == false)//if both x and y is not moving
            {
                isMove = false;//close moving program
            }

            //! Stopping checking procedure ended==============
            
            //?? Something Really Matter ??
            if(timePast >= timeSlice)//if a timeSlice second had past and we need to move
            {
                transform.Translate(change);//then move
                timePast -= timeSlice;// \ ^_^ /
                
            }

            

        }
        //*Move Cam Functioning Area Ended==================================
    
    }//! Update Function Ended ========================

    public void follow(string leader /*If you want to stop following, just change the attribute "followSomeone" to false*/)
    {
        this.leader = GameObject.Find(leader);
        followSomeone = true;
    }


    public void moveCamVertical(float y_target/*Pixel*/, float travelTime/*Second*/)//Move the camera vertically to reach at y_target using travelTime second
    {
        Debug.Log("Get into it");
        isMove = true;
        changeY = true;//? might can delete

        change.y = (y_target - transform.position.y)/travelTime * timeSlice;//get the y distance we need to change per TimeSlice
        //     =  (total distance need to move) / (travel time) * [timeSlice] 
        //     = speed per second * [timeSlice] = distance need to travel per timeSlice

        time_need_y = travelTime;

        //** Description-----------------
        //if travel time is 1s, and change.y is 10px
        //then speed = 10/1 = 10, we need to travel 10px every second, for 1 second
        //and we need to travel (10 * timeSlice) every TimeSlice second to reach target in time_need second

        //so that is why we use the formula above to calculate the distance we need to travel every timeSlice second
        //** Description Ended==============
    }



    public void moveCamHorizontal(float x_target/*Pixel*/, float travelTime/*Second*/)//Move the camera horizontally to reach at x_target using travelTime second 
    {
        Debug.Log("Get into it");
        isMove = true;
        changeX = true;//? might can delete

        

        change.x = (x_target - transform.position.y)/travelTime * timeSlice;//get the x distance we need to change per TimeSlice
        //     =  (total distance need to move) / (travel time) * [timeSlice] 
        //     = speed per second * [timeSlice] = distance need to travel per timeSlice

        time_need_x = travelTime;

        //** Description-----------------
        //if travel time is 1s, and change.x is 10px
        //then speed = 10/1 = 10, we need to travel 10px every second, for 1 second
        //and we need to travel (10 * timeSlice) every TimeSlice second to reach target in time_need second

        //so that is why we use the formula above to calculate the distance we need to travel every timeSlice second
        //** Description Ended==============
    }



    public void setTimeSlice(float SetTimeSlice /*Default is 0.025s*/)
    {
        timeSlice = SetTimeSlice;
    }


}
