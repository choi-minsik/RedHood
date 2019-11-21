using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMove : MonoBehaviour
{
    public bool push_on = false;
    public Transform player_dir;
    Rigidbody _rigidbody;
    public Vector3 box_dir;
    public float speed = 1.0f;
    Quaternion a;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (push_on == true)
            move();
        else
            box_dir.Set(0, 0, 0);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Push"))
        {
            push_on = true;
        }
    }


    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Push"))
        {
            push_on = false;
        }
    }
    void move()
    {
        if (player_dir.localEulerAngles.y < 5 || player_dir.localEulerAngles.y >355)
            box_dir.Set(0, 0, 1);
        else if (player_dir.localEulerAngles.y < 95 && player_dir.localEulerAngles.y > 85)
            box_dir.Set(1, 0, 0);
        else if (player_dir.localEulerAngles.y < 185 && player_dir.localEulerAngles.y > 175)
            box_dir.Set(0, 0, -1);
        else if (player_dir.localEulerAngles.y < 275 && player_dir.localEulerAngles.y > 265)
            box_dir.Set(-1, 0, 0);

        box_dir = box_dir.normalized * speed * Time.deltaTime;
        _rigidbody.MovePosition(transform.position + box_dir);

        //if (player_dir.localEulerAngles.y < 5 && player_dir.localEulerAngles.y > 355)
        //    _rigidbody.AddForce(Vector3.forward*100, ForceMode.Force);
    }
   
   
}
