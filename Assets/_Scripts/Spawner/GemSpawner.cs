using System;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gemPrefap;

    private float leftRange = -8f;
    private float rightRange = 8f;

    private float timer = 0f;
    private float timeDelay = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool isReady = IsTimeDelayDone();
        bool isGameOver = ScoreManager.Instance.gameOver;


        if (isReady && !isGameOver)
        {
            SpawnGemRandom();
        }
    }

    private bool IsTimeDelayDone()
    {
        timer += Time.deltaTime;

        if (timer < timeDelay)
        {
            return false;
        }

        timer = 0f;
        return true;
    }

    private void SpawnGemRandom()
    {
        float randomPosX = UnityEngine.Random.Range(leftRange,rightRange);
        Vector3 spawnPos = new Vector3(randomPosX, transform.position.y, transform.position.z);

        Instantiate(gemPrefap, spawnPos, Quaternion.identity);
    }
}
