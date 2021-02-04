using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(SortingGroup))]
public class PositionBasedSorting : MonoBehaviour
{
    public const int m_baseSortingOrder = 1000;
    [SerializeField] float m_offset;
    SortingGroup m_group;
    // Start is called before the first frame update
    void Awake()
    {
        m_group = GetComponent<SortingGroup>();
        m_group.sortingOrder = (m_baseSortingOrder - (int)(transform.position.y + m_offset));
    }

    void LateUpdate()
    {
        m_group.sortingOrder = (m_baseSortingOrder - (int)(transform.position.y + m_offset));
    }
}
