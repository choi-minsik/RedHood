using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float di;
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        di = 0;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        di += speed * Time.deltaTime;
        if (di >= 100)
        {
            Boom();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Boom();
    }

    void Boom()
    {
        Transform obj = GameDATA.Instance.effectPooling.Get_bullet_Effect();
        obj.position = transform.position;
        obj.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    void Test()
    {

    }
}
