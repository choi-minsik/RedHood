using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject_timer : MonoBehaviour
{

    public float timer_time;
    public float time_; 
    private void OnEnable()
    {
        time_ = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time_ += Time.deltaTime;
        if (time_ >= timer_time)
        {
            gameObject.SetActive(false);
        }
    }
}
