using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public enum ItemType
    {
        CLOTHING_TOP,
        CLOTHING_SHOES
    }

    [SerializeField] bool m_active;
    [SerializeField] string m_name;
    [SerializeField] string m_description;
    [SerializeField] Sprite m_icon;
    [SerializeField] int m_cost;
    [SerializeField] ItemType m_type;

    public bool Active { get { return m_active; } }
    public string Name { get { return m_name; } }
    public Sprite Icon { get { return m_icon; } }
    public int Cost { get { return m_cost; } }
    public string Description { get { return m_description; } }
    public ItemType Type { get { return m_type; } }
}
