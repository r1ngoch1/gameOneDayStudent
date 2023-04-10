using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f; // скорость персонажа
    public float jumpForce = 500f; // сила прыжка персонажа
    public Transform groundCheck; // объект, который определяет нахождение персонажа на земле
    public float groundRadius = 0.2f; // радиус объекта, который определяет нахождение персонажа на земле
    public LayerMask whatIsGround; // слой, на котором находится земля

    private Rigidbody2D rb; // компонент физики персонажа
    private bool isGrounded; // определяет, находится ли персонаж на земле

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // перемещение персонажа вправо или влево
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);

        // проверка нахождения персонажа на земле
        
    }

    void Update()
    {
        // прыжок персонажа
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
