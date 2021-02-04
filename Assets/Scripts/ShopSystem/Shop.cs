using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public enum ShopType
    {
        Clothing,
        Consumable
    }


    [SerializeField] string m_name;
    [SerializeField] ShopType m_shopType;

    bool m_isOpen;
    bool m_isPlayerInTrigger;
    List<Item> m_items = new List<Item>();
    public string ShopName { get { return m_name; } }
    public ShopType Type { get { return m_shopType; } }
    public List<Item> Items { get { return m_items; } }

    // Start is called before the first frame update
    void Start()
    {
        LoadItems();
        m_isOpen = false;
    }

    void LoadItems()
    {
        Item[] tempItems = Resources.LoadAll<Item>(string.Concat("Items/", m_shopType.ToString()));

        foreach (var item in tempItems)
            if(item.Active)
                m_items.Add(item);
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            m_isPlayerInTrigger = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_isPlayerInTrigger = false;
        }
    }

    public void Update()
    {
        if (m_isOpen | !m_isPlayerInTrigger)
            return;

        if (Input.GetButtonDown("Action"))
        {
            m_isOpen = true;
            GameManager.Instance.ShopInterface.Show(this);
        }
    }

    public void OnClosedInterface()
    {
        m_isOpen = false;
    }
}
