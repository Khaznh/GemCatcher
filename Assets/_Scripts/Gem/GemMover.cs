using UnityEngine;
using UnityEngine.Audio;

public class GemMover : MonoBehaviour
{
    [SerializeField] private float faillingSpeed = 2f;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource = other.GetComponent<AudioSource>();
            audioSource.Play();
            ScoreManager.Instance.AddScore(1);
            Debug.Log("Plus");
            Destroy(gameObject);
        } else if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Decrease");
            ScoreManager.Instance.RemoveScore(1);
            Destroy(gameObject);
        }
    }
}
