using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    public float MoveSpeed => moveSpeed;

    public void Move(Rigidbody rb)
    {
        Vector3 direction = rb.transform.forward * Input.GetAxisRaw("Vertical") + rb.transform.right * Input.GetAxisRaw("Horizontal");
        rb.velocity = direction * MoveSpeed;
    }
}
