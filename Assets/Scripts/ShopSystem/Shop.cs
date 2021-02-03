using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public enum ShopType
    {
        Clothing
    }


    [SerializeField] string m_name;
    [SerializeField] ShopType m_shopType;

    List<Item> m_items = new List<Item>();
    public string ShopName { get { return m_name; } }
    public ShopType Type { get { return m_shopType; } }
    public List<Item> Items { get { return m_items; } }

    // Start is called before the first frame update
    void Start()
    {
        LoadItems();
    }

    void LoadItems()
    {
        Item[] tempItems = Resources.LoadAll<Item>(string.Concat("Items/", m_shopType.ToString()));

        foreach (var item in tempItems)
            if(item.Active)
                m_items.Add(item);
        
    }

    public void ShowInterface()
    {
        GameManager.Instance.ShopInterface.Show(this);
    }
}
