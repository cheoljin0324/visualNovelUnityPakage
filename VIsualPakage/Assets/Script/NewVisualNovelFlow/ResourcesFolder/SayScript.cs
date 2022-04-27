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

