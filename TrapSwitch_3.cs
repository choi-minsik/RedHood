using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSwitch_3 : MonoBehaviour
{
    public List<Trap> trap_case;
    Vector3 rotation;
    Vector3 current_rot;
    int on = 1;
    bool check;
    private void Start()
    {
        current_rot.Set(0.0f, 0.0f, 0.0f);
        rotation.Set(0.0f, 0.0f,1.0f);
        check = true;
    }
   

    private void Update()
    {
        if(on == 1)
        {
            if (current_rot.z < 45.0f)
            {
                transform.localEulerAngles += rotation;
                current_rot += rotation;
            }
            else
            {
                check = true;
            }
        }
        else if(on == -1)
        {
            if (current_rot.z > -45.0f)
            {
                transform.localEulerAngles -= rotation;
                current_rot -= rotation;
            }
            else
            {
                check = true;
            }
        }
    }
    void StoneFireOn()
    {
        on *= -1;
        Trap_On();
    }

    void Trap_On()
    {
        foreach (Trap obj in trap_case)
        {
            obj.Switch_On();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (check == true)
            StoneFireOn();
        check = false;
    }
}
