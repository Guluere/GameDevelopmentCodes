using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using MyBox;

/*!!!Notes: 
 * Script Version (1.0V)
 * By Chan Kwok Chun (Gul)
 * Will be reused in future projects because its perfect for copy and pasting
 * 
 * Update Log:
 * 1.0V 09/03/2023: - Simple introduction giving the ability to add Char and Sprite
 */


[CreateAssetMenu(fileName = "SpriteFontzFace", menuName = "ScriptableObjects/SpriteFontzFace", order = 2)]
[System.Serializable]
public class SpriteFontzFace : ScriptableObject
{
    [System.Serializable]
    public class SpriteOfChar
    {
        public Sprite Sprite;
        public char Char;
    }

    public List<SpriteOfChar> SpriteOfChars = new List<SpriteOfChar>();
}
