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

    public string ShopName { get { return m_name; } }
    public ShopType Type { get { return m_shopType; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowInterface()
    {
        GameManager.Instance.ShopInterface.Show(this);
    }
}
