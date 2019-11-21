using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Bridge : Trap
{
    int on;
    int my_on;
    Vector3 move_Hight;
    float dis;
    float move_speed;
    float delay;
    Vector3 current_Position;
    Transform p_parent;
    Rigidbody _rigidbody;
    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        move_Hight.Set(1.0f, 0.0f, 0.0f);
        dis = 10.0f;
        move_speed= 3.0f;
        my_on = 1;
        on = -1;
        delay = 0;
        current_Position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (on == 1)
        {
            if (transform.position.x < current_Position.x + dis && my_on == 1)
            {
                MovePosition(move_speed);
            }
            else if (transform.position.x > current_Position.x && my_on == -1)
            {
                MovePosition(-move_speed);
            }
            else
            {
                delay += Time.deltaTime;
                if (delay > 2.0f)
                {
                    my_on *= -1;
                    delay = 0;
                }
            }
        }
    }

    void MovePosition(float speed)
    {
        transform.Translate(move_Hight * Time.deltaTime * speed,Space.World);
    }

    override public void Switch_On()
    {
        on *= -1;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Player>().SetMoveType((int)TypeMove.TransMove);
            col.transform.parent = transform;
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.transform.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Player>().SetMoveType((int)TypeMove.RigidMove);
            col.transform.parent = null;
        }
    }
}
