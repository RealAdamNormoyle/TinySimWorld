using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryInterface : UIScreen
{
    [SerializeField] Transform m_contentContainer;
    [SerializeField] GameObject m_itemPrefab;
    List<ShopItem> m_items = new List<ShopItem>();


    public override void Show()
    {
        base.Show();
        GameManager.Instance.Player?.AllowInput(false);
    }

    public override void Hide()
    {
        base.Hide();
        GameManager.Instance.Player?.AllowInput(true);
    }


}
