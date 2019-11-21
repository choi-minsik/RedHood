using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_RatateWall : Trap
{
    int on;
    Vector3 rot;
    Vector3 current_rot;
    int count;
    void Start()
    {
        on = 1;
        rot.Set(0.0f, 1.0f, 0.0f);
    }

    void Update()
    {
       if (current_rot.y < 90.0f * count)
       {
           Turn();
       }
    }

    void Turn()
    {
        transform.localEulerAngles += rot;
        current_rot += rot;
    }

    override public void Switch_On()
    {
        count++;
        if (count > 4)
            count = 1;
        if (current_rot.y >= 360.0f)
            current_rot.y = 0.0f;
    }
}
