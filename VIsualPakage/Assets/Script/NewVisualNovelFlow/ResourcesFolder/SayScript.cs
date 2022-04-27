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
        public string femotion;
        public string semotion;
        public string temotion;

        //배경아이디
        public int backNum_Id;

        //위치
        public string fCPos;
        public string sCPos;
        public string tCPos;

        //말하고 있는 캐릭터
        public int SayChar;
    }


        public class SayScript : MonoBehaviour
        {
        List<DialogueStack> dialogue;
        List<string> s;
        public void Say(string a)
        {
            StartCoroutine(Set(a));
        }

        public void Say(string DiallogueText, string fC_ID, string femotion, int backNum_Id, string fCPos)
        {
            DialogueStack dialogueStack;

            dialogueStack.DialogueText = DiallogueText;
            dialogueStack.fChar_ID = fC_ID;
            dialogueStack.femotion = femotion;
            dialogueStack.backNum_Id = backNum_Id;
            dialogueStack.fCPos = fCPos;
        }

        public void Say(string DiallogueText, string fC_ID, string sC_ID, string femotion, string semotion, int backNum_Id, int SayChar, string fCPos, string sCPos)
        {

        }

        public void Say(string DiallogueText, string fC_ID, string sC_ID, string tC_ID, string femotion, string semotion, string tEmotion, int backNum_Id, int SayChar, string fCPos, string sCPos, string tCPos)
        {

        }

        public void Say(string UsingCG_ID, string useName, string Text)
        {

        }

        IEnumerator Set(string a)
        {
            yield return new WaitForSeconds(2f);
            Debug.Log(a);
        }

}
   
}

