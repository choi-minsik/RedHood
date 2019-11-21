using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Flower : MonoBehaviour
{
    public GameObject player;
    public int cannonNUM;
    public Transform bulletPosition;
    public float attackDistance;
    public float str;
    public float attackDelayTime;
    float a_time = 0;
    Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        float num_Distance = Vector3.Distance(transform.position, player.transform.position);
        if (num_Distance < attackDistance)
        {
            Vector3 vec = player.transform.position - transform.position;
            vec.y = 0;
            vec.Normalize();
            Quaternion targetLook = Quaternion.LookRotation(vec);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetLook, Time.deltaTime * 20.0f);

            a_time += Time.deltaTime;
            if (a_time >= attackDelayTime)
            {
                a_time = 0;
                BulletShoot_cannon obj = GameDATA.Instance.bulletPooling.Get_bullet_cannon();
                if (obj != null)
                {
                    _animator.Play("Attack_Flower_genAttack");
                    obj.transform.position = bulletPosition.position;
                    obj.Set_speed_distance(player.transform.position);
                    obj.gameObject.SetActive(true);

                    Transform obj_effect = GameDATA.Instance.effectPooling.Get_gen_Effect();
                    obj_effect.position = bulletPosition.position;
                    obj_effect.gameObject.SetActive(true);

                }

            }
        }


       
    }
   
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }

    public void Destroy_Weapon()
    {
        gameObject.SetActive(false);
    }
}
