using UnityEngine;

public abstract class FallingItem : MonoBehaviour
{
    [SerializeField] protected float faillingSpeed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        bool isGameOver = ScoreManager.Instance.gameOver;
        if (!isGameOver)
        {
            MovingDown();
        }
    }

    private void MovingDown()
    {
        transform.Translate(faillingSpeed * Time.deltaTime * Vector3.down);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) { }
}
