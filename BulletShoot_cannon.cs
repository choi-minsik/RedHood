using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot_cannon : MonoBehaviour
{
    public SphereCollider s_Collider;
    public MeshRenderer m_Renderer;

    public Vector3 firstPosition;
    public Vector3 TG_position;
    public float journeyTime;
    private float startTime;
    private int range;

    bool boom = false;
    float timer = 0;

    public float str = 20;

    Vector3 BulletSize;
    Vector3 BulletSize_Big;
    Vector3 BulletEffectSize;
    Vector3 BulletEffectSize_Big;
    Vector3 BulletEffectSize_set;
    private void Awake()
    {
        s_Collider = GetComponent<SphereCollider>();
        m_Renderer = GetComponent<MeshRenderer>();
        BulletSize = new Vector3(0.25f, 0.25f, 0.25f);
        BulletSize_Big = new Vector3(0.35f, 0.35f, 0.35f);
        BulletEffectSize = new Vector3(0.70f, 0.70f, 0.70f);
        BulletEffectSize_Big = new Vector3(1.2f, 1.2f, 1.2f);
        gameObject.SetActive(false);
    }



    public void Set_speed_distance(Vector3 _TG_position)
    {
        boom = false;
        firstPosition = transform.position;
        TG_position = _TG_position;
        TG_position.y = -6f;
        startTime = Time.time;
        s_Collider.radius = 0.5f;
        m_Renderer.enabled = true;
    }





    // Update is called once per frame
    void Update()
    {
        if (boom == false)
        {
            Vector3 center = (firstPosition + TG_position) * 0.5f;
            float f = Vector3.Distance(firstPosition, TG_position);
            center.y -= f * 0.3f;
            Vector3 riseRelCenter = firstPosition - center;
            Vector3 setRelCenter = TG_position - center;
            float fracComplete = (Time.time - startTime) / (journeyTime * f);
            transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
            transform.position += center;

        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                timer = 0;
                gameObject.SetActive(false);
            }

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        boom = true;
        s_Collider.radius = 4f;
        m_Renderer.enabled = false;
        Set_Effect(); //폭파 임팩트
        gameObject.SetActive(false);
    }

    void Set_Effect()
    {

    }
}
