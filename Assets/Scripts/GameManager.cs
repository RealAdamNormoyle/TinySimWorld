using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] ShopInterface m_shopInterface;
    [SerializeField] InventoryInterface m_inventoryInterface;
    [SerializeField] GameObject m_mainMenu;
    //[SerializeField] GameObject m_mainMenu;

    GameObject m_playerPrefab;
    GameObject m_cameraPrefab;
    PlayerController m_player;
    CameraController m_camera;

    public PlayerInventory PlayerInventory = new PlayerInventory();
    public PlayerController Player { get { return m_player; } }
    public ShopInterface ShopInterface { get { return m_shopInterface; } }
    public InventoryInterface InventoryInterface { get { return m_inventoryInterface; } }

    // Start is called before the first frame update
    void Start()
    {
        m_playerPrefab = Resources.Load<GameObject>("Player");
        m_cameraPrefab = Resources.Load<GameObject>("Camera");

        m_mainMenu.SetActive(true);
    }

    public void StartGame()
    {
        m_mainMenu.SetActive(false);
        SpawnPlayerAndCamera();
    }

    void SpawnPlayerAndCamera()
    {
        if(m_player)
            return;

        m_player = GameObject.Instantiate(m_playerPrefab).GetComponent<PlayerController>();
        m_camera = GameObject.Instantiate(m_cameraPrefab).GetComponent<CameraController>();
        m_camera.SetTarget(m_player.transform);
    }

    public void PlayerUseItem(Item item)
    {
        PlayerInventory.Items.Remove(item);
    }

    public void PlayerEquipItem(Item item)
    {
        if((int)item.Type < 2)
        {
            PlayerInventory.Items.Remove(item);
            PlayerInventory.Items.Add(PlayerInventory.EquippedItems[(int)item.Type]);
            PlayerInventory.EquippedItems[(int)item.Type] = item;

            Player.EquipClothingItem((ClothingItem)item);
        }
    }
}
