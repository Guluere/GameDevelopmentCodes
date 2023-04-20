using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using MyBox;
using UnityEngine.UI;


/*!!!Notes: 
 * Script Version (1.0V)
 * By Chan Kwok Chun (Gul)
 * Will be reused in future projects because its perfect for copy and pasting
 * 
 * Update Log:
 * 1.0V 09/03/2023: - Simple introduction giving the ability to add Char and Sprite
 */

public class SpriteFontzReference : MonoBehaviour
{
    public virtual void ChangeText(string Text)
    {
        
    }
}

public class SpriteFontz : SpriteFontzReference
{
    public SpriteFontzFace LoadedSpriteFontz; //{ get { return LoadedSpriteFontz; } set { ChangeSpriteFontzFace(value); } }

    private Dictionary<char, Sprite> CharToSprite = new Dictionary<char, Sprite>();

    public List<Image> TargetRenderers = new List<Image>(); //The index they are added will determine the direction the text is written

    public string text { get { return text; } set { ChangeText(value); } }

    public string TestText;

    // Start is called before the first frame update
    void Start()
    {
        ChangeSpriteFontzFace(LoadedSpriteFontz);
    }

    public void ChangeSpriteFontzFace(SpriteFontzFace spriteFontzFace)
    {
        CharToSprite.Clear();
        foreach (SpriteFontzFace.SpriteOfChar spriteOfChar in spriteFontzFace.SpriteOfChars)
        {
            CharToSprite.Add(spriteOfChar.Char, spriteOfChar.Sprite);
        }
        LoadedSpriteFontz = spriteFontzFace;
        ChangeText(text);
    }

    public override void ChangeText(string Text)
    {
        int _Limit = Mathf.Min(Text.Length, TargetRenderers.Count);

        for (int i = 0; i < _Limit; i++)
        {
            TargetRenderers[i].sprite = CharToSprite[Text[i]];
        }

        text = Text;
    }

    [ButtonMethod]
    public void TestTestText()
    {
        text = TestText;
    }
}
