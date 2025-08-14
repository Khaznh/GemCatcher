using UnityEngine;

public class TripleMover : FallingItem
{
    protected override void Start()
    {
        faillingSpeed = 2f;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.Instance.TripScore();
        }
        Destroy(gameObject);
    }
}
