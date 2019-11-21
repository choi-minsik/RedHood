using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_door : Trap
{
    public int on;
    Vector3 move_Hight;
    float dis;
    public float move_speed;
    Vector3 current_Position;
    // Start is called before the first frame update
    void Start()
    {
        move_Hight.Set(0.0f, 1.0f, 0.0f);
        dis = 5.0f;
        //on = -1;
        current_Position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < current_Position.y + dis && on == 1)
        {
            MovePosition(move_speed);
        }
        else if (transform.position.y > current_Position.y && on == -1)
        {
            MovePosition(-move_speed);
        }
    }

    void MovePosition(float speed)
    {
        transform.Translate(move_Hight * Time.deltaTime * speed);
    }

    override public void Switch_On()
    {
        on *= -1;
    }
}
