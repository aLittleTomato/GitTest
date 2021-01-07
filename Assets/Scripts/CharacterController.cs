using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMframework;

public class CharacterController : MonoBehaviour
{
    private float speed = 1f;             //人物速度
    private float dashSpeed = 10f;       //冲刺速度
    private enum IsCool { Ready,Runtime,Cool}; //冲刺的状态枚举
    private IsCool status = 0;                 //冲刺的状态
    private float dashCoolTime = 1.0f;         //冲刺冷却时间
    private float dashInsistTime = 0.3f;       //冲刺持续时间

    //private enum Orientation { Up,Right,Down,Left}; //人物方向枚举
    //private Orientation ori=Orientation.Right;      //人物方向
    private Rigidbody2D rigid;           //人物刚体
    private Animator anim;             //人物动画器
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        anim.SetFloat("speed", x);
        //if (y > 0) ori = Orientation.Up;        //设置方向,好像暂时没啥用
        //else if (y < 0) ori = Orientation.Down;
        //else if (x > 0) ori = Orientation.Right;
        //else if (x < 0) ori = Orientation.Left;
        if (Input.GetKeyDown(KeyCode.Space) && status == IsCool.Ready)    //检测冲刺按键
        {
            StartCoroutine(Cool());
        }
    }
    private void FixedUpdate()
    {
        Vector2 curPos = rigid.position;                                  
        float x = Input.GetAxis("Horizontal");                            
        float y = Input.GetAxis("Vertical");
        Vector2 inputPos = new Vector2(x,y).normalized;  //人物行走
        Vector2 movement = inputPos * speed;                              
        Vector2 movePos = curPos + movement * Time.fixedDeltaTime;        
        rigid.MovePosition(movePos);
        if (status== IsCool.Runtime)                      //人物冲刺
        {
            Vector2 dashMovement = inputPos * dashSpeed;                  
            Vector2 dashPos = curPos + dashMovement * Time.fixedDeltaTime;
            rigid.MovePosition(dashPos);
        }
    }
    IEnumerator Cool()  //冷却时间
    {
        status = IsCool.Runtime;
        yield return new WaitForSeconds(dashInsistTime);//冲刺中
        status = IsCool.Cool;
        yield return new WaitForSeconds(dashCoolTime);//冷却中
        status = IsCool.Ready;
    }
}
