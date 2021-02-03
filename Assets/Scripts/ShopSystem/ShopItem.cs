using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] Text m_nameText;
    [SerializeField] Text m_descriptionText;
    [SerializeField] Text m_sellCostText;
    [SerializeField] Text m_buyCostText;
    [SerializeField] Image m_icon;

    [SerializeField] Button m_buyButton;
    [SerializeField] Button m_sellButton;

    Item m_itemConfig;
    Action<Item> m_buyCallback;
    Action<Item> m_sellCallback;

    public void Setup(Item item,Action<Item> buyCallback, Action<Item> sellCallback)
    {
        m_buyCallback = buyCallback;
        m_sellCallback = sellCallback;
        m_itemConfig = item;
        m_nameText.text = item.Name;
        m_descriptionText.text = item.Description;
        m_sellCostText.text = (item.Cost / 2).ToString();
        m_buyCostText.text = item.Cost.ToString();
        m_icon.sprite = item.Icon;
        RefreshButtons();
    }

    public void RefreshButtons()
    {
        m_buyButton.interactable = m_itemConfig.Cost <= GameManager.Instance.PlayerInventory.Coins;
        m_sellButton.interactable = GameManager.Instance.PlayerInventory.Items.Contains(m_itemConfig);
    }

    public void OnBuyButtonPressed()
    {
        m_buyCallback?.Invoke(m_itemConfig);
    }

    public void OnSellButtonPressed()
    {
        m_sellCallback?.Invoke(m_itemConfig);
    }
}
