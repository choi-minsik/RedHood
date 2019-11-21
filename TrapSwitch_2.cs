using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSwitch_2 : MonoBehaviour
{
    public List<Trap> trap_case;

    MeshRenderer renDerer;

    int switch_change = 1;

    private void Awake()
    {
        renDerer = gameObject.GetComponent<MeshRenderer>();
        renDerer.material.shader = Shader.Find("MK4 Toon/Standard Glow Anim");
        renDerer.material.SetColor("_Emission", Color.white);
    }

    public void CheckCome(GameObject _obj)
    {
        if (_obj.CompareTag("Box"))
        {
            switch_change *= -1;
            if (switch_change == 1)
                renDerer.material.SetColor("_Emission", Color.white);
            else if (switch_change == -1)
                renDerer.material.SetColor("_Emission", Color.green);
            Trap_On();
        }
    }


    void Trap_On()
    {
        foreach (Trap obj in trap_case)
        {
            obj.Switch_On();
        }
    }
}
