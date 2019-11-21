using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Bullet : MonoBehaviour
{
    public float b_speed = 5.0f;

    void Update()
    {
        transform.Translate(0, 0, 1 * b_speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider col)
    {
        //if (col.CompareTag("TrapSwitch"))
            gameObject.SetActive(false);
    }
}
