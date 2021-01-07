using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FMframework
{
    public class UIManager : MonoBehaviour
   {
        private static Dictionary<string, GameObject> UIDict = new Dictionary<string, GameObject>();  //UI名字与对象对应的字典
        private static GameObject uiRoot;
        public static GameObject UIRoot   //根Canvas，如果没有就自动创建一个
        {
            get
            {
                if(!uiRoot)
                {
                    var Prefab = Resources.Load<GameObject>("UIRoot");
                    uiRoot = GameObject.Instantiate(Prefab);
                    uiRoot.name = "UIRoot";
                    return uiRoot;
                }
                else return uiRoot;
            }
            set
            {
                uiRoot = value;
            }
        }

        public static GameObject Load(string name)        //加载一个UI
        {
            var Prefab = Resources.Load<GameObject>(name);
            var UIElements = GameObject.Instantiate(Prefab);
            UIElements.transform.SetParent(UIRoot.transform);
            UIElements.name = name;
            UIDict.Add(name, UIElements);
            return UIElements;
            //酌情加层级功能
        }
        public static void UnLode(string name)      //卸载一个UI
        {
            if (UIDict.ContainsKey(name))
            {
                Destroy(UIDict[name]);
            }
            else throw new Exception("要删除的元素不存在");
        }
        public static void SetScaler(float width, float height,float match)   //设置UI界面大小
        {
            var canvasScaler = UIRoot.GetComponent<CanvasScaler>();
            canvasScaler.referenceResolution = new Vector2(width, height);
            canvasScaler.matchWidthOrHeight = match;
        }
    }
}
