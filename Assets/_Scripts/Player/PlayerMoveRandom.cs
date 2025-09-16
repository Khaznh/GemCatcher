using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PlayerMoveRandom : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(MoveRandom());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator MoveRandom()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);
            MoveToRandomPoint();
        }
    }

    private Vector3 GetRandomPoint()
    {
        return new Vector3(Random.Range(-8f, 8f), -3.540497f, 0);
    }

    private void MoveToRandomPoint()
    {
        transform.DOMove(GetRandomPoint(), 2f);
    }
}
