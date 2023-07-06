using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket h�z�
    public float jumpForce = 5f; // Z�plama kuvveti
    private bool isJumping = false; // Z�plama durumu
    private bool isOnGround = false; // Yerde olma durumu

    private Rigidbody2D rb; // Rigidbody bile�eni referans�

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Yatay hareket al
        float moveX = Input.GetAxis("Horizontal");

        // Karakteri yatay olarak hareket ettir
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // Z�plama kontrolleri
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Yere temas kontrol�
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Yerden ayr�lma kontrol�
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
}

