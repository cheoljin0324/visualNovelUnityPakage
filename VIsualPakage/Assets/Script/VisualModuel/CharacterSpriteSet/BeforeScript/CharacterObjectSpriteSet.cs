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

        if (character.BObjectList.Count == 0 || character.ObjectList[0].GetComponent<SpriteRenderer>().sprite != character.BObjectList[0].GetComponent<SpriteRenderer>().sprite)
        {
            character.ObjectList[0].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
    }
    public void SpriteSet(Sprite FirstSprite,Sprite SecondSprite)
    {
        character.ObjectList[0].GetComponent<SpriteRenderer>().sprite = FirstSprite;
        character.ObjectList[1].GetComponent<SpriteRenderer>().sprite = SecondSprite;
        if (character.BObjectList.Count == 0 || character.ObjectList[0].GetComponent<SpriteRenderer>().sprite != character.BObjectList[0].GetComponent<SpriteRenderer>().sprite)
        {
            character.ObjectList[0].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
        if (character.BObjectList.Count == 0 || character.ObjectList[1].GetComponent<SpriteRenderer>().sprite != character.BObjectList[1].GetComponent<SpriteRenderer>().sprite)
        {
            character.ObjectList[1].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
    }
    public void SpriteSet(Sprite FirstSprite, Sprite SecondSprite, Sprite ThirdSprite)
    {
        character.ObjectList[0].GetComponent<SpriteRenderer>().sprite = FirstSprite;
        character.ObjectList[1].GetComponent<SpriteRenderer>().sprite = SecondSprite;
        character.ObjectList[2].GetComponent<SpriteRenderer>().sprite = ThirdSprite;
        if (character.BObjectList.Count == 0 || character.ObjectList[0].GetComponent<SpriteRenderer>().sprite != character.BObjectList[0].GetComponent<SpriteRenderer>().sprite)
        {
            character.ObjectList[0].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
        if (character.BObjectList.Count == 0 || character.ObjectList[1].GetComponent<SpriteRenderer>().sprite != character.BObjectList[1].GetComponent<SpriteRenderer>().sprite)
        {
            character.ObjectList[0].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
        if (character.BObjectList.Count == 0 || character.ObjectList[2].GetComponent<SpriteRenderer>().sprite != character.BObjectList[2].GetComponent<SpriteRenderer>().sprite)
        {
            character.ObjectList[0].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
    }
}
