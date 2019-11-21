using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_StoneFire : Trap
{
    int on = -1;
    GameObject bullet_head;
    public GameObject bullet;
    float delay = 0;
    // Start is called before the first frame update
    void Awake()
    {
        bullet_head = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (on == 1)
        {
            delay += Time.deltaTime;
            if (bullet.activeInHierarchy == false && delay > 3.0f)
            {
                BulletCreate();
                delay = 0.0f;
            }
        }
    }

    override public void Switch_On()
    {
        on *= -1;
    }

    void BulletCreate()
    {
        bullet.transform.position = bullet_head.transform.position;
        bullet.transform.rotation = bullet_head.transform.rotation;
        bullet.SetActive(true);
    }
}
