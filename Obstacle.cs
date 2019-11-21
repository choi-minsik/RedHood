using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject wall;
   public bool box_come = false;
    public Transform _player;
    public float dis;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
       dis = Mathf.Sqrt(
            ((transform.position.x - _player.transform.position.x) * (transform.position.x - _player.transform.position.x)) +
            ((transform.position.z - _player.transform.position.z) * (transform.position.z - _player.transform.position.z)));
        if (dis <= 1.7f && box_come == false)
            Check(true);
        else if (dis > 1.7f && box_come == false)
            Check(false);
        else if (box_come == true)
            Check(false);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Box"))
        {
            box_come = true;
        }
    }


    void Check(bool chek)
    {
        wall.SetActive(chek);
    }
}
