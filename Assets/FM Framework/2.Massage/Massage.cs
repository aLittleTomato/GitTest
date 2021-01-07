using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace FMframework
{
    public class Show : MonoBehaviour
    {
        [MenuItem("FMramework/2.消息机制")]
        private static void MenuClicked()
        {
            Debug.Log("1,用Register(string name, Action <T> OnMassageRecieved) 注册一个方法  带一个参数,无返回值的函数或者lambda表达式");
            Debug.Log("注意要在Awake里注册函数");
            Debug.Log("2,用Send(string name, T data) 传入参数并执行 只要注册了的方法可以在任何地方使用");
            Debug.Log("3,用完之后记得取消注册");
        }
    }
    public class Massage<T> : MonoBehaviour
    {      
        private static Dictionary<string, Action<T>> Center = new Dictionary<string, Action<T>>();  //消息处理中心
        public static void Register(string name, Action<T> OnMassageRecieved)   //注册消息名和方法
        {
            if (!Center.ContainsKey(name)) Center.Add(name, OnMassageRecieved);
            else Center[name] += OnMassageRecieved;
        }
        public static void UnRegister(string name, Action<T> OnMassageRecieved)  //取消注册特定方法
        {
            Center[name] -= OnMassageRecieved;
        }
        public static void UnRegisterAll(string name)   //取消已经注册的方法
        {
            Center.Remove(name);
        }
        public static void Send(string name, T data)  //发送消息，执行方法
        {
            if (Center.ContainsKey(name)) Center[name](data); //如果已经注册，则执行
            else Debug.Log($"Not Find {name}");
        }
        //以后可能会继续重载
    }
}
