using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum State_idNum
{
    MOVE, ATTACK, CLIMBING
}

public class Player_R : MonoBehaviour
{
    public Camera camera_main;
    public StateMachine<int> state;
    public Transform shootPosition;

    Animator _animator;
    Rigidbody _rigidbody;
    public int speed;
    public int rotatespeed;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        Set_state();
        state.Set_Statebool((int)State_idNum.MOVE, true);
    }
    void Update()
    {
        Play_state();
    }


   
    public void Set_state()
    {
        state = new StateMachine<int>();
        state.Add((int)State_idNum.MOVE, Move_State);
        state.Add((int)State_idNum.ATTACK, Attack_State);
        state.Add((int)State_idNum.CLIMBING, Climbing_State);
    }
    //--------------------------------------------------------------------------
    public void Play_state()
    {
        state.Execution();
    }
    public float h;
    public float v;
    Vector3 movement;
    public void Move_State()
    {
        if(state.Get_Statebool((int)State_idNum.ATTACK)==false)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
            if (h == 0 && v == 0)
                return;
            movement.Set(h, 0, v);
            movement = movement.normalized * speed * Time.deltaTime;
            _rigidbody.MovePosition(transform.position + movement);

            Quaternion targetRot = Quaternion.LookRotation(movement);
            Quaternion frameRot = Quaternion.RotateTowards(transform.rotation,
                                                           targetRot,
                                                           rotatespeed * Time.deltaTime);
            transform.rotation = frameRot;
        }
    }
    float timeRe;
    public void Attack_State()
    {
        Vector3 pos;
        pos.x = target_pos.x;
        pos.y = 0;
        pos.z = target_pos.y;
        //pos = pos - transform.position;
       // Quaternion newrotation = Quaternion.LookRotation(pos);
       // transform.rotation = Quaternion.Slerp(transform.rotation, newrotation, rotatespeed * Time.deltaTime);
        
        Quaternion targetRot = Quaternion.LookRotation(pos);
        Quaternion frameRot = Quaternion.RotateTowards(transform.rotation,
                                                       targetRot,
                                                       (rotatespeed*1.2f) * Time.deltaTime);
      
        transform.rotation = frameRot;
        if (transform.rotation.y <= targetRot.y + 0.01f && transform.rotation.y >= targetRot.y- 0.01f)
        {
            transform.rotation = targetRot;
            Transform obj = GameDATA.Instance.bulletPooling.Get_Bullet();
            obj.position = shootPosition.position;
            obj.rotation = transform.rotation;
            obj.gameObject.SetActive(true);

            Transform obj_effect = GameDATA.Instance.effectPooling.Get_gen_Effect();
            obj_effect.position = shootPosition.position;
            obj_effect.gameObject.SetActive(true);

            state.Set_Statebool((int)State_idNum.ATTACK, false);

            _animator.Play("genAttack");
        }



        print("r");
    }
    public void Climbing_State()
    {

    }
    //--------------------------------------------------------------------------
    Vector2 target_pos;
    public void Shoot(Vector2 pos)
    {
        state.Set_Statebool((int)State_idNum.ATTACK, true);
       
        pos = pos.normalized;


        target_pos = pos;
        timeRe = 0;
    }

}
