using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float playerSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private int jumpNumber = 0;
    [SerializeField] private GameObject smokePrefaps;
    [SerializeField] private Transform smokePos;
    private Animator animator;
    private Rigidbody2D playuerRigidbody2D;

    private float playerRangeNega = -8.3f;
    private float playerRangePosi = 8.3f;

    private Coroutine speedCoroutine;
    public bool isSpeedUp = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        playuerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = GetUserInput();

        bool isMoving = horizontalInput != 0;

        if (jumpNumber < 2 &&Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            PlayerJump();
        }

        if (transform.position.x < playerRangeNega)
        {
            transform.position = new Vector3(playerRangeNega,transform.position.y,0);
        }

        if (transform.position.x > playerRangePosi)
        {
            transform.position = new Vector3(playerRangePosi, transform.position.y, 0);
        }

        if (isMoving)
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
        float horizontalMovement = horizontalInput * playerSpeed;
        //transform.position = new Vector2(transform.position.x + horizontalMovement, transform.position.y);
        playuerRigidbody2D.linearVelocity = new Vector2(horizontalMovement, playuerRigidbody2D.linearVelocity.y);
    }

    private void PlayerJump()
    {
        playuerRigidbody2D.linearVelocity = new Vector2(playuerRigidbody2D.linearVelocity.x, jumpForce);
        jumpNumber++;
    }

    public IEnumerator ApplySpeed(float multiply, float timer)
    {
        if (speedCoroutine != null)
        {
            StopCoroutine(speedCoroutine);
            playerSpeed /= multiply; 
        }

        speedCoroutine = StartCoroutine(SpeedRoutine(multiply, timer));
        yield break;
    }

    private IEnumerator SpeedRoutine(float multiply, float timer)
    {
        isSpeedUp = true;
        playerSpeed *= multiply;

        yield return new WaitForSeconds(timer);

        playerSpeed /= multiply;
        isSpeedUp = false;
        speedCoroutine = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpNumber = 0;
        }
    }
}
