using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket hýzý
    public float jumpForce = 5f; // Zýplama kuvveti
    private bool isJumping = false; // Zýplama durumu
    private bool isOnGround = false; // Yerde olma durumu

    private Rigidbody2D rb; // Rigidbody bileþeni referansý

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

        // Zýplama kontrolleri
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Yere temas kontrolü
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Yerden ayrýlma kontrolü
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
}

