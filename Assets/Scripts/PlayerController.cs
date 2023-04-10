using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f; // �������� ���������
    public float jumpForce = 500f; // ���� ������ ���������
    public Transform groundCheck; // ������, ������� ���������� ���������� ��������� �� �����
    public float groundRadius = 0.2f; // ������ �������, ������� ���������� ���������� ��������� �� �����
    public LayerMask whatIsGround; // ����, �� ������� ��������� �����

    private Rigidbody2D rb; // ��������� ������ ���������
    private bool isGrounded; // ����������, ��������� �� �������� �� �����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // ����������� ��������� ������ ��� �����
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);

        // �������� ���������� ��������� �� �����
        
    }

    void Update()
    {
        // ������ ���������
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}
