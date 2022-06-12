using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualNovelControler : MonoBehaviour
{
    //���־�� ������ ��
    VisualSet dataSet;
    //������Ʈ ��
    ObjectSet objectSet;
    //���̾� ��Ʈ�ѷ�(���̾�α� ������Ʈ ������)
    DialogueControler dialControl;
    //�ؽ�Ʈ ������
    TextControler textCon;
    //ĳ���� ������
    CharacetObControler CharCon;
    BackControl backCon;

    EventCGControler EventControler;

    //���̵� ���ΰ�?(Y/N) �⺻ ���� N
    public bool isFade = false;
    public int isBack = 0;

    void Awake()
    {
        //ĳ�� �� Find
        objectSet = GameObject.Find("ObjectSetOb").GetComponent<ObjectSet>();
        dialControl = GameObject.Find("ObjectSetOb").GetComponent<DialogueControler>();
        textCon = GameObject.Find("TextManager").GetComponent<TextControler>();
        backCon = GameObject.Find("BackSprite").GetComponent<BackControl>();
        CharCon = GetComponent<CharacetObControler>();
        dataSet = GetComponent<VisualSet>();
        EventControler = GetComponent<EventCGControler>();
    }


    /// <summary>
    /// ĳ���� ����
    /// </summary>
    void DelOB()
    {
        CharCon.CharDel();
    }

    /// <summary>
    /// ���̾�α� ������Ʈ
    /// </summary>
    /// <returns></returns>
    public bool UpdateDialogue()
    {
        //���� ù��° �α��϶�
        if (dataSet.isFirst == true)
        {
            for(int i = 0; i<backCon.BackOBject.Count; i++)
            {
                if(dataSet.dialogue[dataSet.currentDialogueIndex].backName != i)
                {
                    backCon.OutSetting(i);
                }
            }
            if (dataSet.dialogue[dataSet.currentDialogueIndex].dialogueEvent == DialogueIs.DialogueEven.EventCG)
            {
                EventControler.CreateEvent();
                EventControler.eventSpriteSets();
                EventControler.OnEventCG(dataSet.dialogue[dataSet.currentDialogueIndex].EventCGSprite);
            }

            //�ʱ� ��� ���� ���� �� ��������Ʈ �ʱ�ȭ
            backCon.InSetting(dataSet.dialogue[dataSet.currentDialogueIndex].backName);
            //ĳ���� ��Ʈ�ѷ��� ĳ���� ���� �Լ��� ����
            CharCon.CreaterCharacetOb();
            //������ ���� ĳ���� ��ġ ����ŭ
            for(int i = 0; i<dataSet.dialogue[dataSet.currentDialogueIndex].charintPos.Length; i++)
            {
                //ĳ���� ��ġ �ʱ�ȭ
                CharCon.SetPos(i);
            }
            //���� ���̾�α� ����
            SetNextDialogue();
            //ó�� ����ȴٴ� bool ���� false�� ó�� ����Ǵ� ���̾�αװ� �����δ� �ƴ��� �ݱ�
            dataSet.isFirst = false;
        }
        //�ƴҰ��
        else
        {
            //���� ���콺 ��ư�� Ŭ�� ���� ���
            if (Input.GetMouseButtonUp(0))
            {
                //�ؽ�Ʈ ��Ʈ���� Ÿ���� ���� ���
                if (textCon.isTyping == true)
                {
                    //Ÿ���� ���
                    textCon.isTyping = false;
                }
                else
                {
                    //���� �����Ϳ� ���̾�α� ������ ���� ���̾�α� �ε��� ������ Ŭ ���
                    if (dataSet.dialogue.Length > dataSet.currentDialogueIndex + 1)
                    {
                        //���� �α׸� ����
                        SetNextDialogue();
                    }
                    //������ ���̾�α��� ���
                    else
                    {
                       //���̾� ��Ʈ�ѿ� �ƿ� ���̵�� ���̾�ڽ��� ���̵�
                        dialControl.FadeOutDial(dialControl.DialBox);
                        //����
                        DelOB();
                        //�ؽ�Ʈ ��Ʈ���� ���̾� ����
                        textCon.DeleteDial();
                        //�ؽ�Ʈ ��Ʈ���� �̸� ����
                        textCon.DeleteName();
                        
                        //true ���� �����ָ� ���� �ڷ�ƾ�� �����ϰ� �Ѵ�.
                        return true;
                    }

                }


            }
        }
        //false ���� �����ָ� ����ؼ� ���̾�α׸� �����Ų��.
        return false;
    }


    /// <summary>
    /// ���� ��ȭ ����
    /// </summary>
    public void SetNextDialogue()
    {
        if (dataSet.isFirst == false)
        {
            EventControler.OffEventCG(dataSet.dialogue[dataSet.currentDialogueIndex].EventCGSprite);
        }
           
        //���� ù��° ���̾�αװ� �ƴ϶��
        if (dataSet.isFirst == false)
        {
            //���̾�α׸� 1++
            dataSet.currentDialogueIndex++;
            if(dataSet.isFirst==false&&dataSet.dialogue[dataSet.currentDialogueIndex].dialogueEvent == DialogueIs.DialogueEven.EventCG)
            {
                EventControler.OnEventCG(dataSet.dialogue[dataSet.currentDialogueIndex].EventCGSprite);
            }

            //���� ����� �ٸ� ���
            if(dataSet.dialogue[dataSet.currentDialogueIndex - 1].backName!= dataSet.dialogue[dataSet.currentDialogueIndex].backName)
            {
                //��� ���� �� ����
                backCon.OutSetting(dataSet.dialogue[dataSet.currentDialogueIndex - 1].backName);
                backCon.InSetting(dataSet.dialogue[dataSet.currentDialogueIndex].backName);
            }
            //�̸��� �ش� ���̾�α� �����Ϳ� �����ϰ� �ٲ��ش�.
            textCon.UpdateName(dataSet.simChar[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[dataSet.dialogue[dataSet.currentDialogueIndex].nowMent].charNumber].Name);
            //��ȭ �����͸� �ش� ���̾�α� �����Ϳ� �����ϰ� �ٲ��ش�.
            textCon.UpdateDial(dataSet.dialogue[dataSet.currentDialogueIndex].DialogueData);
            //���� ������ ���� ���� ���̾�α� �ε����� ���̾�α� ���̿� ���� ���
            if (dataSet.currentDialogueIndex == dataSet.dialogue.Length)
            {
                //��� ĳ���͸� ����
                CharCon.DelFade();
            }
            else
            {
                //�ƴ� ��� ĳ���� ��Ʈ�ѿ� �̸�ǰ� Ʈ���� �� ���鼭 ���ǿ� �´� ������Ʈ ���� �ٲ��ش�.
                CharCon.EmotionFade();
                CharCon.TransPos();
            }
           
        }
        //���� ó���� ���
        else
        {
            //������Ʈ �����Ҷ� ���� ���̵� ȿ�� ����
            CharCon.CreateFade();
            //���ο� ���̾� ����
            dialControl.NewDial(objectSet.DialBox);

            //�̸� �ؽ�Ʈ ����
            textCon.InstName();
            //���̾�α� ����
            textCon.InstDial();

            textCon.ReStart();

            //�̸� ������Ʈ
            textCon.UpdateName(dataSet.simChar[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[dataSet.dialogue[dataSet.currentDialogueIndex].nowMent].charNumber].Name);
            //���̾� ������Ʈ
            textCon.UpdateDial(dataSet.dialogue[dataSet.currentDialogueIndex].DialogueData);
        }


    }

}
