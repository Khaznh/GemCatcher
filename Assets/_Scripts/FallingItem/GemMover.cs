using UnityEngine;
using UnityEngine.Audio;

public class GemMover : FallingItem
{
    private AudioSource audioSource;

    protected override void Start()
    {
        faillingSpeed = 4f;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource = other.GetComponent<AudioSource>();
            audioSource.Play();
            ScoreManager.Instance.AddScore(1);
        }
        Destroy(gameObject);
    }
}
