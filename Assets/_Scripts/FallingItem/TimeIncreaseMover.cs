using UnityEngine;

public class TimeIncreaseMover : FallingItem
{
    protected override void Start()
    {
        faillingSpeed = 4f;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.Instance.AddGameTime(20);
        }
        Destroy(gameObject);
    }
}
