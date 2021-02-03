using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] ShopInterface m_shopInterface;
    [SerializeField] GameObject m_mainMenu;

    GameObject m_playerPrefab;
    PlayerController m_player;
    
    public PlayerController Player { get { return m_player; } }
    public ShopInterface ShopInterface { get { return m_shopInterface; } }


    // Start is called before the first frame update
    void Start()
    {
        m_playerPrefab = Resources.Load<GameObject>("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlayer()
    {
        if(m_player)
            return;


        m_player = GameObject.Instantiate(m_playerPrefab).GetComponent<PlayerController>();
    }
}
