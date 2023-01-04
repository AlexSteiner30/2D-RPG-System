using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_speed;

    float horizontal;
    float vertical;

    private void Update()
    {
        Inputs();
        Move();
    }

    private void Inputs()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void Move()
    {
        transform.Translate(new Vector2(horizontal, vertical) * m_speed / 2500);
    }
}
