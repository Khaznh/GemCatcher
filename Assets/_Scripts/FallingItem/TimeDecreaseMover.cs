using UnityEngine;

public class TimeDecreaseMover : FallingItem
{
    protected override void Start()
    {
        faillingSpeed = 4f;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.Instance.ReduceGameTime(20);
        }
        Destroy(gameObject);
    }
}
