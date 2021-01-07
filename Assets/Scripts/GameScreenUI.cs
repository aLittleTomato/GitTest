using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMframework;

public class GameScreenUI : MonoBehaviour
{
    private Slider hp;//血量
    private Text level;//等级
    private void Awake()
    {
        Massage<float>.Register("GetHurt", (monsterAttack) => { GetHurt(monsterAttack);});//注册受伤的方法
        Massage<int>.Register("SetLevel", (value) => { SetLevel(value);});//注册设置等级方法
    }
    void Start()
    {
        hp = transform.GetChild(0).GetComponent<Slider>();//获取canvas下第一个血量子物体
        hp.maxValue = MainCharacter.HP; hp.value = MainCharacter.HP; //初始化人物血量

        level = transform.GetChild(1).GetComponent<Text>();//获取canvas下第二个等级子物体
        Massage<int>.Send("SetLevel", MainCharacter.Level); //初始化人物等级
    }
    private void GetHurt(float monsterAttack)//受伤函数
    {
        float damage = FMframework.MainCharacter.Defense - monsterAttack;
        if (damage > 0) damage = 0;
        hp.value+=damage;
    }
    private void SetLevel(int value)
    {
        level.text = $"等级:{value}";//以后按策划要求用富文本改一下，现在先这样
        level.fontSize = 24;
    }
}
