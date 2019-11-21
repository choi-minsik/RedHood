using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{
    public GameObject bullet;
    List<Transform> bullet_case = new List<Transform>();

    public GameObject bullet_cannon;
    List<BulletShoot_cannon> bullet_cannon_case = new List<BulletShoot_cannon>();

    // Start is called before the first frame update
    void Start()
    {
        Make_bullet();
        Make_bullet_cannon();
    }
    
    void Make_bullet()
    {
        for (int i = 0; i < 30; i++) 
        {
            Transform obj = Instantiate(bullet).transform;
            obj.parent = transform;
            bullet_case.Add(obj);
        }
    }

    public Transform Get_Bullet()
    {
        for (int i = 0; i < bullet_case.Count; i++)
        {
            if(!bullet_case[i].gameObject.activeInHierarchy)
            {
                return bullet_case[i];
            }
        }
        return null;
    }

    void Make_bullet_cannon()
    {
        for (int i = 0; i < 30; i++)
        {
            Transform obj = Instantiate(bullet_cannon).transform;
            obj.parent = transform;
            bullet_cannon_case.Add(obj.GetComponent<BulletShoot_cannon>());
        }
    }

    public BulletShoot_cannon Get_bullet_cannon()
    {
        for (int i = 0; i < bullet_cannon_case.Count; i++)
        {
            if (!bullet_cannon_case[i].gameObject.activeInHierarchy)
            {
                return bullet_cannon_case[i];
            }
        }
        return null;
    }


}
