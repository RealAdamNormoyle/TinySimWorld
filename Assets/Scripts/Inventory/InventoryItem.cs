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
    Action<Item> m_equipCallback;

    public void Setup(Item item, Action<Item> equipCallback)
    {
        m_item = item;
        m_nameText.text = item.Name;
        m_icon.sprite = item.Icon;

        m_equipCallback = equipCallback;
        m_equipButton.SetActive(true);
        m_useButton.SetActive(false);    
    }

    public void OnEquipButtonPressed()
    {
        m_equipCallback?.Invoke(m_item);
    }
}
