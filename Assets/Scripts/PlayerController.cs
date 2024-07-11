using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f; // Высота прыжка, можно настроить в инспекторе
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private bool canJump = true; // Флаг, разрешающий прыжок

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckGround();
        Move();
        Jump();
        UpdateAnimationState();
    }

    private void Move()
    {
        float moveDirection = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        if (moveDirection != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveDirection), 1, 1);
        }

        animator.SetBool("IsWalking", Mathf.Abs(moveDirection) > 0.1f);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // Сброс вертикальной скорости перед прыжком
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
            canJump = false; // Запретить новый прыжок до следующего соприкосновения с землей
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            canJump = true; // Разрешить прыжок, если персонаж на земле
        }
    }

    private void UpdateAnimationState()
    {
        animator.SetBool("IsJumping", !isGrounded);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death"))
        {
            animator.SetTrigger("IsDead");
        }
    }
}






