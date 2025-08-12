using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = GetUserInput();

        bool isMoving = horizontalInput != 0;
        bool isGameOver = ScoreManager.Instance.gameOver;

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
}
