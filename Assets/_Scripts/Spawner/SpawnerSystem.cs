using UnityEngine;

public abstract class SpawnerSystem : MonoBehaviour
{
    [SerializeField] protected GameObject prefap;
    [SerializeField] private float delayTimeForIntro = 5f;

    private float leftRange = -8f;
    private float rightRange = 8f;

    private float timer = 0f;
    [SerializeField] protected float timeDelay = 5f;
    private bool isIntro = true;

    // Update is called once per frame
    void Update()
    {
        bool isReady = IsTimeDelayDone();
        bool isGameOver = ScoreManager.Instance.isWin;

        if (isReady && !isGameOver)
        {
            SpawnRandom();
        }
    }

    private bool IsTimeDelayDone()
    {
        timer += Time.deltaTime;

        float currentDelay = isIntro ? delayTimeForIntro + timeDelay : timeDelay;

        if (timer < currentDelay)
        {
            return false;
        }

        timer = 0f;
        return true;
    }

    private void SpawnRandom()
    {
        float randomPosX = UnityEngine.Random.Range(leftRange, rightRange);
        Vector3 spawnPos = new Vector3(randomPosX, transform.position.y, transform.position.z);

        Instantiate(prefap, spawnPos, Quaternion.identity);

        if (isIntro) isIntro = false;
    }
}
