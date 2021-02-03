﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class ShopInterface : UIScreen
{
    [SerializeField] Text m_titleText;
    [SerializeField] Text m_coinsText;
    [SerializeField] Text m_gemsText;
    [SerializeField] Transform m_storeContentContainer;
    [SerializeField] GameObject m_itemPrefab;

    Shop m_activeShop;
    List<ShopItem> m_items = new List<ShopItem>();

    public void Show(Shop shop)
    {
        base.Show();
        m_activeShop = shop;
        UpdateStoreDetails();
        UpdateStoreContent();

        GameManager.Instance.Player?.AllowInput(false);
    }

    public override void Hide()
    {
        base.Hide();
        GameManager.Instance.Player?.AllowInput(true);
    }

    void UpdateStoreDetails()
    {
        m_titleText.text = m_activeShop.ShopName;
        m_coinsText.text = GameManager.Instance.PlayerInventory.Coins.ToString();
        m_gemsText.text = GameManager.Instance.PlayerInventory.Gems.ToString();
    }

    void UpdateStoreContent()
    {
        for (int i = 0; i < m_items.Count;)
        {
            Destroy(m_items[0].gameObject);
            m_items.RemoveAt(0);
        }

        foreach (var item in m_activeShop.Items)
        {
            ShopItem shopItem = GameObject.Instantiate(m_itemPrefab,m_storeContentContainer).GetComponent<ShopItem>();
            shopItem.Setup(item,BuyItem,SellItem);
        }

    }

    void UpdateItemButtons()
    {
        for (int i = 0; i < m_items.Count;i++)
        {
            m_items[i].RefreshButtons();
        }
    }

    public void BuyItem(Item item)
    {
        if (GameManager.Instance.PlayerInventory.Coins < item.Cost)
            return;

        GameManager.Instance.PlayerInventory.Coins -= item.Cost;
        GameManager.Instance.PlayerInventory.Items.Add(item);

        UpdateItemButtons();
    }

    public void SellItem(Item item)
    {
        if (!GameManager.Instance.PlayerInventory.Items.Contains(item))
            return;

        if(GameManager.Instance.PlayerInventory.Items.Remove(item))
            GameManager.Instance.PlayerInventory.Coins += item.Cost / 2;

        UpdateItemButtons();
    }
}
