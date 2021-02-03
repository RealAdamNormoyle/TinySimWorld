using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T m_instance;
    [SerializeField] 
    private bool m_dontDestroyOnLoad = true;

    public static T Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<T>();

                if (m_instance == null)
                {
                    var go = new GameObject();
                    go.hideFlags = HideFlags.DontSave;
                    go.name = typeof(T).Name + " (Singleton)";
                    m_instance = go.AddComponent<T>();
                }
            }

            return m_instance;
        }
    }

    protected virtual void Awake()
    {
        if (m_dontDestroyOnLoad)
            DontDestroyOnLoad(this);

        if (m_instance == null)
            m_instance = this as T;
        else
            Destroy(gameObject);
    }

}
