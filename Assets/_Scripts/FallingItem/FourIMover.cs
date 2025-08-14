using UnityEngine;

public class FourtMover : FallingItem
{
    protected override void Start()
    {
        faillingSpeed = 2f;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.Instance.FourScore();
        }
        Destroy(gameObject);
    }
}
