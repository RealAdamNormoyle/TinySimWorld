using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{
    public bool IsMoving { get { return m_lookDirection != Vector2.zero; } }
    [SerializeField] CharacterPartCollection[] m_partCollections;
    
    Animator m_anim;
    Vector2 m_lookDirection = Vector2.zero;

    void Start()
    {
        m_anim = GetComponent<Animator>();
        HideAllParts();
        m_partCollections[0].gameObject.SetActive(true);

    }

    public void UpdateLookDirection(Vector2 dir)
    {
        m_lookDirection = dir;

        if (IsMoving)
        {
            HideAllParts();
            if(dir.y > 0)
            {
                m_partCollections[2].gameObject.SetActive(true);
            }else if(dir.y < 0)
            {
                m_partCollections[0].gameObject.SetActive(true);
            }
            else
            {
                m_partCollections[1].gameObject.SetActive(true);
                transform.localScale = new Vector3((m_lookDirection.x < 0) ? 0.3f : -0.3f, 0.3f, 1);
            }
        }
    }

    public void SetClothingSprites(Item.ItemType type, Sprite[] sprites)
    {
        switch (type)
        {
            case Item.ItemType.CLOTHING_TOP:
                for (int i = 0; i < 3; i++)
                {
                    m_partCollections[i].SetBodySprite(sprites[i]);
                }
                break;
            case Item.ItemType.CLOTHING_SHOES:
                for (int i = 0; i < 3; i++)
                {
                    m_partCollections[i].SetShoeSprite(sprites[i]);
                }
                break;
        }
    }

    void HideAllParts()
    {
        m_partCollections[0].gameObject.SetActive(false);
        m_partCollections[1].gameObject.SetActive(false);
        m_partCollections[2].gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        m_anim.SetBool("Walking", IsMoving);
    }
}