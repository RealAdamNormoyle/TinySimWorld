using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryInterface : UIScreen
{
    [SerializeField] Transform m_contentContainer;
    [SerializeField] GameObject m_itemPrefab;
    List<InventoryItem> m_items = new List<InventoryItem>();


    public override void Show()
    {
        base.Show();
        GameManager.Instance.Player?.AllowInput(false);
        UpdateContent();
    }

    public override void Hide()
    {
        base.Hide();
        GameManager.Instance.Player?.AllowInput(true);
    }

    void UpdateContent()
    {
        for (int i = 0; i < m_items.Count;)
        {
            Destroy(m_items[0].gameObject);
            m_items.RemoveAt(0);
        }

        foreach (var item in GameManager.Instance.PlayerInventory.Items)
        {
            InventoryItem inventoryItem = GameObject.Instantiate(m_itemPrefab, m_contentContainer).GetComponent<InventoryItem>();
            if(item.Type == Item.ItemType.CONSUMABLE)
                inventoryItem.Setup(item, OnUseItem);
            else
                inventoryItem.Setup(item, OnEquipItem);
            
            m_items.Add(inventoryItem);
        }
    }

    public void OnEquipItem(Item item)
    {
        GameManager.Instance.PlayerEquipItem(item);
        UpdateContent();
    }

    public void OnUseItem(Item item)
    {
        GameManager.Instance.PlayerUseItem(item);
        UpdateContent();
    }
}
