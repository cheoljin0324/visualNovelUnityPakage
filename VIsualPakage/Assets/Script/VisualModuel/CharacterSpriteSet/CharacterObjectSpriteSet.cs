using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterObjectSpriteSet : MonoBehaviour
{
    CharacterObjectSet character;
    // Start is called before the first frame update

    private void Awake()
    {
        character = GetComponent<CharacterObjectSet>();
    }

    public void SpriteSet(Sprite FirstSprite)
    {
        character.ObjectList[0].GetComponent<SpriteRenderer>().sprite = FirstSprite;
    }
    public void SpriteSet(Sprite FirstSprite,Sprite SecondSprite)
    {
        character.ObjectList[0].GetComponent<SpriteRenderer>().sprite = FirstSprite;
        character.ObjectList[1].GetComponent<SpriteRenderer>().sprite = SecondSprite;
    }
    public void SpriteSet(Sprite FirstSprite, Sprite SecondSprite, Sprite ThirdSprite)
    {
        character.ObjectList[0].GetComponent<SpriteRenderer>().sprite = FirstSprite;
        character.ObjectList[1].GetComponent<SpriteRenderer>().sprite = SecondSprite;
        character.ObjectList[2].GetComponent<SpriteRenderer>().sprite = ThirdSprite;
    }
}
