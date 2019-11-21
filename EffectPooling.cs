using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPooling : MonoBehaviour
{
    public GameObject gen_Effect;
    public GameObject bullet_Effect;
    List<Transform> gen_Effect_case = new List<Transform>();
    List<Transform> bullet_Effect_case = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        Make_gen_Effect();
        Make_bullet_Effect();
    }
    void Make_gen_Effect()
    {
        for (int i = 0; i < 30; i++)
        {
            Transform obj = Instantiate(gen_Effect).transform;
            obj.parent = transform;
            gen_Effect_case.Add(obj);
        }
    }
    public Transform Get_gen_Effect()
    {
        for (int i = 0; i < gen_Effect_case.Count; i++)
        {
            if (!gen_Effect_case[i].gameObject.activeInHierarchy)
            {
                return gen_Effect_case[i];
            }
        }
        return null;
    }
    void Make_bullet_Effect()
    {
        for (int i = 0; i < 30; i++)
        {
            Transform obj = Instantiate(bullet_Effect).transform;
            obj.parent = transform;
            bullet_Effect_case.Add(obj);
        }
    }
    public Transform Get_bullet_Effect()
    {
        for (int i = 0; i < bullet_Effect_case.Count; i++)
        {
            if (!bullet_Effect_case[i].gameObject.activeInHierarchy)
            {
                return bullet_Effect_case[i];
            }
        }
        return null;
    }
}
