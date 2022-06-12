using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DSFEngine
{
    public class ScritControler : MonoBehaviour
    {
        public delegate void SetCg(string CharID, int Emotion, int Pos);
        public Action<int> set;
        public Action<string, int, int, string, int, int> SetCgS;
        public Action<string, int, int, string, int, int, string, int, int> SetCgT;
        public static Func<int, int> SetPos;

        public static SetCg setcg;

        private void Start()
        {
            setcg = new SetCg(SetStandCG.SetSprite);
            SetCgS += SetStandCG.SetSprite;
            SetCgT += SetStandCG.SetSprite;
            SetPos += SetPosition.setPosition;
            set = SetPosition.set;
        }
    }
}

