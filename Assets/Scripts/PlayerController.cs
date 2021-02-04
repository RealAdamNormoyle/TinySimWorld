using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_walkSpeed = 1;

    Character m_character;
    Vector2 m_movementDirection;
    bool m_allowMove;
    bool m_allowInput;

    void Start()
    {
        m_character = GetComponentInChildren<Character>();
        m_allowMove = true;
        m_allowInput = true;
    }

    void Update()
    {
        if (m_allowInput)
            ProcessInput();
    }

    private void FixedUpdate()
    {
        m_character.UpdateLookDirection(m_movementDirection);

        if (m_allowInput && m_allowMove)
            Movement();
    }

    void ProcessInput()
    {
        m_movementDirection.y = (int)Input.GetAxis("Vertical");
        m_movementDirection.x = (int)Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Inventory"))
        {
            GameManager.Instance.InventoryInterface.Show();
        }
    }

    void Movement()
    {
        transform.Translate((Vector3)m_movementDirection * (m_walkSpeed * Time.fixedDeltaTime),Space.World);
    }

    public void AllowInput(bool val)
    {
        m_allowInput = val;
    }

}
