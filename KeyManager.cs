using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
  //  public player_test _player_test;
    public Player_R player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MouseTouch_MapMaker();
    }
    public Vector2 pos_m;
    public Vector2 pos_p;
    void MouseTouch_MapMaker()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(player.state.Get_Statebool((int)State_idNum.ATTACK) == false)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    player.Shoot(hit.point);
                }

                pos_m = Input.mousePosition;
                pos_p = Camera.main.WorldToScreenPoint(player.transform.position);
             
                    player.Shoot( pos_m - pos_p);
            }
              
        }
        if (Input.GetMouseButtonDown(1))
        {
         
        }

    }
}
