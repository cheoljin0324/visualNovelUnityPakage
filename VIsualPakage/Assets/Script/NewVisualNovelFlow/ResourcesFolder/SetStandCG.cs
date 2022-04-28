using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSFEngine
{
    public class SetStandCG : MonoBehaviour
    {
        Action<SpriteRenderer> setPos;
        private void Start()
        {
            setPos += SetPosition.setPosition;
        }



        public static void SetSprite(string CharID, int Emotion)
        {
            GameObject charSprite = Instantiate(DialogueCLS.Inst.stainding);
            SpriteRenderer charSpriteRend = charSprite.GetComponent<SpriteRenderer>();
            for(int i = 0; i<DialogueCLS.Inst.characters.Length; i++)
            {
                if(CharID == DialogueCLS.Inst.characters[i].charName)
                {
                    if(Emotion == 0)
                    {
                        charSpriteRend.sprite = DialogueCLS.Inst.characters[i].MainChar;
                    }
                    else
                    {
                        charSpriteRend.sprite = DialogueCLS.Inst.characters[i].CharEmotion[Emotion];
                    }
                }

                
            }
            

        }

        public static void SetSprite(string fCharID, string sCharID)
        {

        }

        public static void SetSprite(string fCharID, string sCharID, string tCharID)
        {

        }
            
    }

}
