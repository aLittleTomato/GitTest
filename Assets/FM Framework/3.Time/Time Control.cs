using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace FMframework
{
    public class TimeControl : MonoBehaviour
    {
        [MenuItem("FMramework/3.时间类方法")]
        private static void MenuClicked()
        {
            Debug.Log("延迟执行使用方法:StartCoroutine(TimeControl.Delay(() =>{ 要执行的代码段或者无参数无返回值的函数 },delaySeconds));");
        }
        public static IEnumerator Delay(Action action, float delaySeconds) //延迟执行方法
        {
            yield return new WaitForSeconds(delaySeconds);
            action();
        }
    }
}
