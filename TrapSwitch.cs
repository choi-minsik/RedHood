using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSwitch : MonoBehaviour
{

    public List<Trap> trap_case;

    MeshRenderer renDerer;

    int switch_change = 1;

    private void Awake()
    {
        renDerer = gameObject.GetComponent<MeshRenderer>();
        renDerer.material.shader = Shader.Find("MK4 Toon/Standard Glow Anim");
        renDerer.material.SetColor("_Emission", Color.red);
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Stone")
        {
            switch_change *= -1;
            if (switch_change == 1)
                renDerer.material.SetColor("_Emission", Color.red); 
            else if (switch_change == -1)
                renDerer.material.SetColor("_Emission", Color.yellow);
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
