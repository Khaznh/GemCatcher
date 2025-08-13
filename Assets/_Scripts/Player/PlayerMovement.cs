using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private bool isInGround = false;
    [SerializeField] private float jumpForce = 10f;
    private Animator animator;
    private Rigidbody2D playuerRigidbody2D;

    void Start()
    {
        animator = GetComponent<Animator>();
        playuerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = GetUserInput();

        bool isMoving = horizontalInput != 0;
        bool isGameOver = ScoreManager.Instance.gameOver;

        if (isInGround && Keyboard.current.spaceKey.isPressed)
        {
            PlayerJump();
        }

        if (isMoving && !isGameOver)
        {
            animator.SetBool("isMoving", true);
            MoveHorizontal(horizontalInput);
        } else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private float GetUserInput()
    {
        return Input.GetAxis("Horizontal");
    }

    private void MoveHorizontal(float horizontalInput)
    {
        float horizontalMovement = horizontalInput * playerSpeed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + horizontalMovement, transform.position.y);
    }

    private void PlayerJump()
    {
        playuerRigidbody2D.linearVelocity = new Vector2(playuerRigidbody2D.linearVelocity.x, jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isInGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isInGround = false;
        }
    }
}
