using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform m_target;


    public void SetTarget(Transform target)
    {
        m_target = target;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (m_target == null)
            return;

        transform.position = Vector2.Lerp(transform.position, m_target.position,10*Time.deltaTime);
    }
}
