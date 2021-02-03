using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewClothingItem", menuName = "Shop/Items/ClothingItem", order = 0)]
public class ClothingItem : Item
{
    public enum SpriteDirection
    {
        Up,
        Down,
        Side
    }

    [SerializeField] Sprite[] m_sprites;
    public Sprite[] Sprites { get {return m_sprites; } }
}
