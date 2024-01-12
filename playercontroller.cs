using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float doubleJumpForce;
    [SerializeField]
    private Rigidbody2D myRigidbody;
    private Animator animator;
    private bool isFacingRight = true;
    private int jumpCount = 0;
    
    

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Run();

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        UpdateAnimation();
    }


    private void Run()
    {
        float moveDir = Input.GetAxis("Horizontal");
        Vector2 playerVel = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVel;

        if (moveDir > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveDir < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void Jump()
    {
        if (jumpCount < 2)
        {
            if (jumpCount == 0)
            {
                myRigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
            else if (jumpCount == 1)
            {
                myRigidbody.AddForce(new Vector2(0f, doubleJumpForce), ForceMode2D.Impulse);
            }

            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }
    private void UpdateAnimation()
    {
        float moveDir = Input.GetAxis("Horizontal");

        if (moveDir != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        animator.SetFloat("VerticalVelocity", myRigidbody.velocity.y);
        animator.SetBool("IsJumping", jumpCount > 0);
    }
}