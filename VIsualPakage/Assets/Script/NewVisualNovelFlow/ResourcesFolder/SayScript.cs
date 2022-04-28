using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSFEngine
{


    public enum DialType
        {
            One,Two,Three,Event
        }

        public struct DialogueStack
        {
        //이벤트 CG일때 사용 할 CG
        public string UsingCG_ID;

        //이름
        public string useName;
        //대화 내용
        public string DialogueText;

        //캐릭터 아이디
        public string fChar_ID;
        public string sChar_ID;
        public string tChar_ID;

        //감정
        public int femotion;
        public int semotion;
        public int temotion;

        //배경아이디
        public int backNum_Id;

        //위치
        public int fCPos;
        public int sCPos;
        public int tCPos;

        //말하고 있는 캐릭터
        public int SayChar;
    }


        public class SayScript : ScriptControler
    {

        public delegate void setDel(string CharID, int Emotion);
        List<DialogueStack> dialogue;
        public void Say(string a)
        {
            StartCoroutine(Set(a));
        }

        public void Say(string DiallogueText, string fC_ID, int femotion, int backNum_Id, int fCPos)
        {

            DialogueStack dialogueStack;

            dialogueStack.DialogueText = DiallogueText;
            dialogueStack.fChar_ID = fC_ID;
            dialogueStack.femotion = femotion;
            dialogueStack.backNum_Id = backNum_Id;
            dialogueStack.fCPos = fCPos;

            SetCg(fC_ID,femotion,fCPos);

        }

        public void Say(string DiallogueText, string fC_ID, int femotion, int fCPos, string sC_ID, int semotion, int sCPos, int backNum_Id, int SayChar)
        {
            DialogueStack dialogueStack;

            dialogueStack.DialogueText = DiallogueText;
            dialogueStack.fChar_ID = fC_ID;
            dialogueStack.sChar_ID = sC_ID;
            dialogueStack.femotion = femotion;
            dialogueStack.semotion = semotion;
            dialogueStack.backNum_Id = backNum_Id;
            dialogueStack.SayChar = SayChar;
            dialogueStack.fCPos = fCPos;
            dialogueStack.sCPos = sCPos;
        }

        public void Say(string DiallogueText, string fC_ID, string sC_ID, string tC_ID, int femotion, int semotion, int tEmotion, int backNum_Id, int SayChar, int fCPos, int sCPos, int tCPos)
        {
            DialogueStack dialogueStack;

            dialogueStack.DialogueText = DiallogueText;
            dialogueStack.fChar_ID = fC_ID;
            dialogueStack.sChar_ID = sC_ID;
            dialogueStack.tChar_ID = tC_ID;
            dialogueStack.femotion = femotion;
            dialogueStack.semotion = semotion;
            dialogueStack.temotion = tEmotion;
            dialogueStack.backNum_Id = backNum_Id;
            dialogueStack.SayChar = SayChar;
            dialogueStack.fCPos = fCPos;
            dialogueStack.sCPos = sCPos;
            dialogueStack.tCPos = tCPos;
        }

        public void Say(string UsingCG_ID, string useName, string DialogueText)
        {
            DialogueStack dialogueStack;
            dialogueStack.UsingCG_ID = UsingCG_ID;
            dialogueStack.useName = useName;
            dialogueStack.DialogueText = DialogueText;
        }

        IEnumerator Set(string a)
        {
            yield return new WaitForSeconds(2f);
            Debug.Log(a);
        }

}
   
}

