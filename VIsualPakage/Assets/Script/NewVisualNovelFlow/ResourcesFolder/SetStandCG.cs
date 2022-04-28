using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSFEngine
{
    public class SetStandCG : ScriptControler
    {



        public static void SetSprite(string CharID, int Emotion, int Pos)
        { 
            for(int i = 0; i<DialogueCLS.Inst.characters.Length; i++)
            {
                if(CharID == DialogueCLS.Inst.characters[i].charName)
                {
                    if(Emotion == 0)
                    {
                        DialogueCLS.Inst.spriteRenderer[SetPos(Pos)].sprite = DialogueCLS.Inst.characters[i].MainChar;
                    }
                    else
                    {
                        DialogueCLS.Inst.spriteRenderer[SetPos(Pos)].sprite = DialogueCLS.Inst.characters[i].CharEmotion[Emotion];
                    }
                }
       
                
            }
            

        }

        public static void SetSprite(string fCharID, int fEmotion, int fPos, string sCharID , int sEmotion ,int sPos)
        {

        }

        public static void SetSprite(string fCharID, int fEmotion, int fPos, string sCharID, int sEmotion, int sPos,string tCharID,int tEmotion, int tPos)
        {

        }
            
    }

}
