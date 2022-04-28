using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSFEngine
{
    public class SetPosition : MonoBehaviour
    {
        public static void setPosition(SpriteRenderer CGSprite)
        {
            CGSprite.transform.position = new Vector2(0, 0);
        }
    }
}

