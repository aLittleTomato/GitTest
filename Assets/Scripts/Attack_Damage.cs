using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMframework;

public class Attack_Damage : MonoBehaviour
{
    private Rigidbody2D rigid;
    private float x;
    private float y;
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();      
    }

    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision 可以获取一个怪物状态collision.gameObject.GetComponent<脚本名字>().怪物的状态和攻击力  hurt里传入怪物的攻击力    
        if (collision.gameObject.tag == "Enemy")//&&状态为攻击)//先暂时碰撞的时候调用
        {
            StartCoroutine(Hurt(/*collision里的攻击力*/));
            StartCoroutine(Repelled(new Vector2(rigid.position.x - collision.rigidbody.position.x,0).normalized));
        }
    }
    IEnumerator Repelled(Vector2 v)//v可以传入与怪物的相对位置，但效果不太好，以后再改
    {
        gameObject.GetComponent<CharacterController>().enabled = false;//暂时禁止移动
        for (int i = 0; i < 30; i++)
        {
            rigid.AddRelativeForce(v * 0.5f * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
        gameObject.GetComponent<CharacterController>().enabled = true;
    }
    IEnumerator Hurt(/*float 怪物攻击力等等之类的让策划来想*/)
    {
        Massage<float>.Send("GetHurt", 3.0f);//随便输了个3，以后想改再说
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}