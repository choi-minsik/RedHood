using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_positoin : MonoBehaviour {
    
    public Transform player;


    public float xMargin = 0f;
    public float zMargin = 0f;
    public float yMargin = 0f;

    public float xSmooth = 5f;
    public float zSmooth = 5f;
    public float ySmooth = 2f;

    public Vector2 minXandY;
    public Vector2 maxXandY;

    float original_x;
    float original_y;
    float original_z;
    void Awake()
    {
        original_x = transform.position.x;
        original_y = transform.position.y;
        original_z = transform.position.z;
    }
    
    void FixedUpdate()
    {
                float targetX = transform.position.x;
                float targetZ = transform.position.z;

                float targetY = transform.position.x;

        if (CheckXMargin()) 
        {
            targetX = Mathf.Lerp(transform.position.x, player.position.x, Time.deltaTime * xSmooth);
        }
  

        if (CheckZMargin()) 
        {
            targetZ = Mathf.Lerp(transform.position.z, player.position.z -7, Time.deltaTime * zSmooth);
        }
   

        if (CheckYMargin())
        {
            targetY = Mathf.Lerp(transform.position.y, player.position.y + 12, Time.deltaTime * ySmooth);
        }
            transform.position = new Vector3(targetX, targetY, transform.position.z);
            transform.position = new Vector3(transform.position.x, targetY, targetZ);
        //if (targetX >= -88 && targetX <= 24.4f)
        //    transform.position = new Vector3(targetX, targetY, transform.position.z);
        //if (targetZ >= -21 && targetZ <= 78)
        //    transform.position = new Vector3(transform.position.x, targetY, targetZ);
    }
    float Reset_go_Time;
    float set_position_x;
    float set_position_y;
    float set_position_z;
    float old_position_x;
    float old_position_y;
    float old_position_z;
    
    bool CheckXMargin()
    {
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }
    bool CheckZMargin()
    {
        return Mathf.Abs(transform.position.z-7 - player.position.z) > zMargin;
    }
    bool CheckYMargin()
    {
        return Mathf.Abs(transform.position.y + 12 - player.position.z) > yMargin;
    }


}
