using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class ShopInterface : MonoBehaviour
{
    [SerializeField] Text m_titleText;
    [SerializeField] Text m_coinsText;
    [SerializeField] Text m_gemsText;
    [SerializeField] Transform m_storeContentContainer;

    CanvasGroup m_canvas;
    Shop m_activeShop;

    public void Show(Shop shop)
    {
        m_canvas.alpha = 1;
        m_canvas.blocksRaycasts = true;
        m_canvas.interactable = true;

        GameManager.Instance.Player?.AllowInput(false);

        m_activeShop = shop;
    }

    public void Hide()
    {
        m_canvas.alpha = 0;
        m_canvas.blocksRaycasts = false;
        m_canvas.interactable = false;

        GameManager.Instance.Player?.AllowInput(true);
    }

    void UpdateStoreDetails()
    {

    }

    void UpdateStoreContent()
    {

    }
}
