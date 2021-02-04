using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class UIScreen : MonoBehaviour
{
    CanvasGroup m_canvas;

    public virtual void Awake()
    {
        m_canvas = GetComponent<CanvasGroup>();
    }

    public virtual void Start()
    {
        Hide();
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
            Hide();
    }

    public virtual void Show()
    {
        m_canvas.alpha = 1;
        m_canvas.blocksRaycasts = true;
        m_canvas.interactable = true;
    }

    public virtual void Hide()
    {
        m_canvas.alpha = 0;
        m_canvas.blocksRaycasts = false;
        m_canvas.interactable = false;
    }


}
