using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPartCollection : MonoBehaviour
{
    [SerializeField] SpriteRenderer m_face;
    [SerializeField] SpriteRenderer m_head;
    [SerializeField] SpriteRenderer m_body;
    [SerializeField] SpriteRenderer m_leftShoe;
    [SerializeField] SpriteRenderer m_rightShoe;

    public void SetHeadSprite(Sprite sprite) { m_head.sprite = sprite; }
    public void SetBodySprite(Sprite sprite) { m_body.sprite = sprite; }
    public void SetShoeSprite(Sprite sprite) { m_leftShoe.sprite = m_rightShoe.sprite = sprite; }

}

[System.Serializable]
public class CharacterSpriteCollection
{
    public Sprite Front;
    public Sprite Back;
    public Sprite Side;
}
