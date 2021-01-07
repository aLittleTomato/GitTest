using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FMframework
{
    public class MainCharacter : MonoBehaviour
    {
        public static float bodyConstitution = 1;
        public static float BodyConstitution//体质
        {
            get
            {
                return bodyConstitution;
            }
        }

        private static float rationality = 1;
        public static float Rationality//理性
        { 
            get
            {
                return rationality;
            }
        }

        private static float insanity = 1;
        public static float Insanity//精神
        { 
            get
            {
                return insanity;
            }
        }

        private static float imagination = 1;
        public static float Imagination//想象
        { 
            get
            {
                return imagination;
            }
        }

        private static float dexterous = 1;
        public static float Dexterous//灵巧
        { 
            get
            {
                return dexterous;
            }
        }

        private static int level = 1;
        public static int Level//等级
        { 
            get
            {
                return level;
            }
        }
        public static float HP//血量
        { 
            get
            {
                return 100*BodyConstitution;
            }
        }
        /// <summary>
        /// 以上属性能显示在游戏界面
        /// 以下属性由上面的值决定
        /// </summary>       
        public static float Attack
        {
            get
            {
                return Level + BodyConstitution;
            }
        }//攻击力
        public static float Defense
        {
            get
            {
                return BodyConstitution;
            }
        }//防御力
        public static float San { get; set; }//San值
        public static float AttackSpeed
        { 
            get
            {
                return Dexterous;
            }
        }//攻击速度
        public static float MoveSpeed
        {
            get
            {
                return Dexterous;
            }
        }//移动速度
        public static float Luck { get; set; }//幸运
        public static float Magic { get; set; }//魔法攻击
    }
}
