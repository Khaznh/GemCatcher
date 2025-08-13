using UnityEngine;

public class SnowBallMover : FallingItem
{
    protected override void Start()
    {
        faillingSpeed = 3f;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.Instance.RemoveScore(1);
        }
        Destroy(gameObject);
    }
}
