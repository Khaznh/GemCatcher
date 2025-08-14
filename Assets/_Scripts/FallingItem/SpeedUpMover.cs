using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class SpeedUpMover : FallingItem
{
    [SerializeField] private float speedMultiply = 2f;
    [SerializeField] private float speedUpTime = 5f;


    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            StartCoroutine(playerMovement.ApplySpeed(speedMultiply,speedUpTime));
        }
        Destroy(gameObject);
    }
}
