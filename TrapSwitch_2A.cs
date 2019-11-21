using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSwitch_2A : MonoBehaviour
{
    TrapSwitch_2 myParent_Trap;
    private void Awake()
    {
        myParent_Trap = GetComponentInParent<TrapSwitch_2>();
    }
    private void OnTriggerEnter(Collider col)
    {
        myParent_Trap.CheckCome(col.gameObject);
    }
    private void OnTriggerExit(Collider col)
    {
        myParent_Trap.CheckCome(col.gameObject);
    }
}
