using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] Text m_nameText;
    [SerializeField] Image m_icon;
    [SerializeField] GameObject m_equipButton;
    [SerializeField] GameObject m_useButton;

    Item m_item;
    Action<Item> m_callback;

    public void Setup(Item item, Action<Item> callback)
    {
        m_item = item;
        m_nameText.text = item.Name;
        m_icon.sprite = item.Icon;
        m_callback = callback;

        if(m_item.Type == Item.ItemType.CONSUMABLE)
        {
            m_equipButton.SetActive(false);
            m_useButton.SetActive(true);
        }
        else
        {
            m_equipButton.SetActive(true);
            m_useButton.SetActive(false);
        }
 
    }

    public void OnEquipButtonPressed()
    {
        m_callback?.Invoke(m_item);
    }

}
