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
        //�̺�Ʈ CG�϶� ��� �� CG
        public string UsingCG_ID;

        //�̸�
        public string useName;
        //��ȭ ����
        public string DialogueText;

        //ĳ���� ���̵�
        public string fChar_ID;
        public string sChar_ID;
        public string tChar_ID;

        //����
        public string femotion;
        public string semotion;
        public string temotion;

        //�����̵�
        public int backNum_Id;

        //��ġ
        public string fCPos;
        public string sCPos;
        public string tCPos;

        //���ϰ� �ִ� ĳ����
        public int SayChar;
    }


        public class SayScript : MonoBehaviour
        {
        public Action<string, string> SetSCG = SetStandCG.SetSprite;

        public delegate void setDel(string CharID, int Emotion);
        List<DialogueStack> dialogue;
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

            SetSCG(fC_ID,femotion);
        }

        public void Say(string DiallogueText, string fC_ID, string sC_ID, string femotion, string semotion, int backNum_Id, int SayChar, string fCPos, string sCPos)
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

        public void Say(string DiallogueText, string fC_ID, string sC_ID, string tC_ID, string femotion, string semotion, string tEmotion, int backNum_Id, int SayChar, string fCPos, string sCPos, string tCPos)
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

