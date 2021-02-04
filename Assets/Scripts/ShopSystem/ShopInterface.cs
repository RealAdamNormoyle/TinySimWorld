using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class ShopInterface : UIScreen
{
    [SerializeField] Text m_titleText;
    [SerializeField] Text m_coinsText;
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
        m_activeShop?.OnClosedInterface();
        GameManager.Instance.Player?.AllowInput(true);
    }

    void UpdateStoreDetails()
    {
        m_titleText.text = $"{m_activeShop.ShopName} Merchant";
        m_coinsText.text = GameManager.Instance.PlayerInventory.Coins.ToString();
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
            m_items.Add(shopItem);
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
        m_coinsText.text = GameManager.Instance.PlayerInventory.Coins.ToString();

    }

    public void SellItem(Item item)
    {
        if (!GameManager.Instance.PlayerInventory.Items.Contains(item))
            return;

        if(GameManager.Instance.PlayerInventory.Items.Remove(item))
            GameManager.Instance.PlayerInventory.Coins += item.Cost / 2;

        UpdateItemButtons();
        m_coinsText.text = GameManager.Instance.PlayerInventory.Coins.ToString();

    }
}
